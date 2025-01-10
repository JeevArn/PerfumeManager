namespace PerfumeManager;

public class SearchCommand : Command
{
    public SearchCommand(PerfumeManager perfumeManager, string[] commandArguments)
        : base(perfumeManager, commandArguments)
    {
        if (commandArguments.Length < 2)
        {
            isValid = false;
        }
    }

    public override void Execute()
    {
        if (!isValid)
        {
            Console.Error.WriteLine("Invalid arguments. Usage: search <criterion> <value>");
            Console.WriteLine("Criteria: id, name, note, scentprofile");
            return;
        }

        string criterion = arguments[0].ToLower();
        string value = arguments[1];

        List<Perfume> results = criterion switch
        {
            "id" => SearchById(value),
            "name" => SearchByName(value),
            "brand" => SearchByBrand(value),
            "note" => SearchByNote(value),
            "scentprofile" => SearchByScentProfile(value),
            _ => null
        };

        if (results == null || results.Count == 0)
        {
            Console.WriteLine($"No perfumes found for the criterion '{criterion}' and value '{value}'.");
        }
        else
        {
            foreach (Perfume perfume in results)
            {
                PrintPerfume(perfume);
            }
        }
    }

    private List<Perfume> SearchById(string value)
    {
        if (int.TryParse(value, out int id))
        {
            Perfume perfume = PerfumeManager.Get(id);
            return perfume != null ? new List<Perfume> { perfume } : new List<Perfume>();
        }

        Console.Error.WriteLine("Invalid ID format.");
        return new List<Perfume>();
    }

    private List<Perfume> SearchByName(string value)
    {
        Perfume perfume = PerfumeManager.Get(value);
        return perfume != null ? new List<Perfume> { perfume } : new List<Perfume>();
    }

    private List<Perfume> SearchByBrand(string value)
    {
        return PerfumeManager.GetAll()
            .Where(p => p.Brand.Equals(value, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    private List<Perfume> SearchByNote(string value)
    {
        return PerfumeManager.GetAll()
            .Where(p => p.Notes.Any(note => note.Equals(value, StringComparison.OrdinalIgnoreCase)))
            .ToList();
    }

    private List<Perfume> SearchByScentProfile(string value)
    {
        if (Enum.TryParse<ScentProfile>(value, true, out ScentProfile scentProfile))
        {
            return PerfumeManager.GetAll()
                .Where(p => p.ScentProfile == scentProfile)
                .ToList();
        }

        Console.Error.WriteLine("Invalid scent profile.");
        return new List<Perfume>();
    }

    private void PrintPerfume(Perfume perfume)
    {   
        Console.WriteLine($"-----------------------------------");
        Console.WriteLine($"ID: {perfume.Id}");
        Console.WriteLine($"Name: {perfume.Name}");
        Console.WriteLine($"Brand: {perfume.Brand}");
        Console.WriteLine($"Notes: {string.Join(", ", perfume.Notes)}");
        Console.WriteLine($"ScentProfile: {perfume.ScentProfile}");
        Console.WriteLine();
    }
}
