namespace PerfumeManager;

public class LoadCommand : Command
{
    public LoadCommand(PerfumeManager perfumeManager, string[] commandArguments)
        : base(perfumeManager, commandArguments)
    {
        if (commandArguments.Length < 1)
        {
            isValid = false;
        }
    }

    public override void Execute()
    {
        if (!isValid)
        {
            Console.Error.WriteLine("Insufficient arguments provided.");
            return;
        }

        string path = arguments[0];

        if (!File.Exists(path))
        {
            Console.Error.WriteLine($"File [{path}] not found.");
            return;
        }

        using StreamReader reader = new StreamReader(path);

        int count = 0;
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            string[] parts = line.Split(';');
            if (parts.Length < 5)
            {
                Console.Error.WriteLine($"Error parsing line: [{line}]. Insufficient parts.");
                continue;
            }

            try
            {
                int id = int.Parse(parts[0]);
                // replacing spaces with _
                // to handle multiword names and notes such as 'tonka bean'
                string name = parts[1].Replace(" ", "_");
                string brand = parts[2].Replace(" ", "_");
                
                List<string> notes = parts[3].Split(",")
                    .Select(note => note.Trim('[', ']', ' ').ToLower().Replace(" ", "_"))
                    .ToList();

                ScentProfile.TryParse(parts[4], out ScentProfile scentProfile);

                Perfume perfume = new Perfume(id, name, brand, notes, scentProfile);

                // Ensure no duplicates are loaded
                if (PerfumeManager.Get(id) != null)
                {
                    Console.Error.WriteLine($"Duplicate perfume ID found: {id}. Skipping.");
                    continue;
                }

                PerfumeManager.Add(perfume);
                count++;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error processing line: [{line}]. {ex.Message}");
            }
        }

        Console.WriteLine($"{count} perfumes successfully loaded from file.");
    }
}
