namespace PerfumeManager;

public class PerfumeManager
{
    private static List<string> commandHistory = new List<string>();

    public static void LogCommand(string command)
    {
        commandHistory.Add(command);
    }

    public static List<string> GetHistory()
    {
        return new List<string>(commandHistory);
    }

    Perfume[] perfumes = new Perfume[151]; 

    public PerfumeManager()
    {
    }

    public PerfumeManager(PerfumeManagerDto perfumeManagerDto)
    {
        LoadDto(perfumeManagerDto);
    }

    public void LoadDto(PerfumeManagerDto perfumeManagerDto)
    {
        foreach (PerfumeDto perfumeDto in perfumeManagerDto.Perfumes) 
        {
            Perfume perfume = new Perfume(perfumeDto);
            perfumes[perfume.Id] = perfume; 
        }
    }

    public void Add(Perfume p)
    {
        perfumes[p.Id] = p; 
    }

    public Perfume Get(int id)
    {
        return perfumes[id]; 
    }

    public Perfume Get(string name)
    {
        foreach (Perfume perfume in perfumes)
        {
            if (perfume != null && perfume.Name.ToLower() == name.ToLower()) 
            {
                return perfume;
            }
        }

        return null;
    }

    public IEnumerable<Perfume> GetAll()    
    {
        return perfumes.Where(p => p != null);
    }

    public Perfume[] GetByScentProfile(ScentProfile scentProfile)
    {
        int arraySize = 0; 

        foreach (Perfume perfume in perfumes) 
        {
            if (perfume != null && perfume.ScentProfile.HasFlag(scentProfile)) 
            {
                arraySize++;
            }
        }

        int index = 0; 
        Perfume[] result = new Perfume[arraySize]; 

        foreach (Perfume perfume in perfumes) 
        {
            if (perfume != null && perfume.ScentProfile.HasFlag(scentProfile)) 
            {
                result[index++] = perfume;
            }
        }

        return result;
    }

    public void Save(StreamWriter file)
    {
        foreach (Perfume perfume in perfumes) 
        {
            if (perfume != null) 
            {
                file.WriteLine(perfume.ToString()); 
            }
        }
    }

    public PerfumeManagerDto ToDto()
    {
        return new PerfumeManagerDto
        {
            Perfumes = perfumes
                .Where(p => p != null) 
                .Select(p => p.ToDto()) 
                .ToArray() 
        };
    }
}
