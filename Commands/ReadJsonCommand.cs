using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace PerfumeManager;

// Deserialise PerfumeManager from JSON
public class ReadJsonCommand : Command
{
    public ReadJsonCommand(
        PerfumeManager perfumeManager,
        string[] commandArguments)
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
            Console.Error.WriteLine("Invalid arguments. Usage: writejson <path>");
            return;
        }

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Latin1Supplement),
        };

        try
        {
            string path = $"{arguments[0]}";
            string content = File.ReadAllText(path);

            PerfumeManagerDto perfumeManagerDto = JsonSerializer.Deserialize<PerfumeManagerDto>(content, options);
            PerfumeManager.LoadDto(perfumeManagerDto);

            Console.WriteLine("Successful deserialisation!");
        }
        catch
        {
            Console.WriteLine("File not found");
        }
    }
}
