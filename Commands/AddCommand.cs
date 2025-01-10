namespace PerfumeManager;

public class AddCommand : Command
{
    public AddCommand(PerfumeManager perfumeManager, string[] commandArguments)
        : base(perfumeManager, commandArguments)
    {
        if (commandArguments.Length < 5)
        {
            isValid = false;
        }
    }

    // add 50 Terracotta Guerlain vanille,ylang-ylang Floral
    public override void Execute()
    {
        if (!isValid)
        {
            Console.Error.WriteLine($"Not enough arguments");

            return;
        }

        // Parse 5 arguments
        if (!int.TryParse(arguments[0], out int perfumeIndex))
        {
            Console.Error.WriteLine($"Error parsing id '{arguments[0]}'");

            return;
        }

        string perfumeName = arguments[1];

        string perfumeBrand = arguments[2];

        List<string> perfumeNotes = arguments[3].Split(',').ToList();

        if (!ScentProfile.TryParse(arguments[4], out ScentProfile perfumeScentProfile))
        {
            Console.Error.WriteLine($"ScentProfile {arguments[4]} not recognized");

            return;
        }

    
        Perfume perfume = new Perfume(perfumeIndex, perfumeName, perfumeBrand, perfumeNotes, perfumeScentProfile);
        PerfumeManager.Add(perfume);

        Console.WriteLine($"Perfume {perfume.Name} added to the perfume manager.");
    }
}
