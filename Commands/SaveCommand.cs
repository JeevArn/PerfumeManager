namespace PerfumeManager;

public class SaveCommand : Command
{
    public SaveCommand(PerfumeManager perfumeManager, string[] commandArguments)
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
            Console.Error.WriteLine("Invalid arguments. Usage: save <csvfilepath>");
            return;
        }

        string path = AddExtension(arguments[0]);

        try
        {
            using StreamWriter streamWriter = new StreamWriter(path);
            foreach (Perfume perfume in PerfumeManager.GetAll())
            {
                string notes = string.Join(",", perfume.Notes);
                string line = $"{perfume.Id};{perfume.Name};{perfume.Brand};{notes};{perfume.ScentProfile}";
                streamWriter.WriteLine(line);
            }

            Console.WriteLine($"PerfumeManager successfully saved to {path}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Failed to save PerfumeManager to {path}: {ex.Message}");
        }
    }

    private string AddExtension(string path)
    {
        if (!path.Contains("."))
        {
            return $"{path}.csv";
        }

        return path;
    }
}
