namespace PerfumeManager;

public class PerfumeDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Brand { get; set; }

    public List<string> Notes { get; set; }

    public ScentProfile ScentProfile { get; set; }

}