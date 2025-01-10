namespace PerfumeManager;

public class Perfume
{
    string separator = ";";

    public int Id { get; private set; }

    public string Name { get; private set; }

    public string Brand { get; private set; }

    public List<string> Notes { get; private set; }

    public ScentProfile ScentProfile { get; private set; }

    public Perfume(int id, string name, string brand, List<string> notes, ScentProfile scentProfile)
    {
        Id = id;
        Name = name;
        Brand = brand;
        Notes = notes;
        ScentProfile = scentProfile;
    }

    public Perfume(PerfumeDto dto)
    {
        Id = dto.Id;
        Name = dto.Name;
        Brand = dto.Brand;
        Notes = dto.Notes;
        ScentProfile = dto.ScentProfile;
    }

    public PerfumeDto ToDto()
    {   
        return new PerfumeDto
        {
            Id = Id,
            Name = Name,
            Brand = Brand,
            Notes = Notes,
            ScentProfile = ScentProfile
        };
    }

    public override string ToString()
    {
        return $"{Id}{separator}{Name}{separator}{Brand}{separator}{string.Join(separator, Notes)}{separator}{ScentProfile}";
    }

    public static void Documentation()
    {
        Console.WriteLine("Class representing a perfume");
    }
}
