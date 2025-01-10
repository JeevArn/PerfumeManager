using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace PerfumeManager;

// Serialize the PerfumeManager to a JSON file
public class WriteJsonCommand : Command
{
    public WriteJsonCommand(
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
            Console.Error.WriteLine("Invalid arguments. Usage: write_json <jsonfilepath>");
            return;
        }

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Latin1Supplement)
        };

        try
        {
            string path = $"{arguments[0]}";

            PerfumeManagerDto perfumeManagerDto = PerfumeManager.ToDto();
            string jsonContent = JsonSerializer.Serialize(perfumeManagerDto, options);

            File.WriteAllText(path, jsonContent);

            Console.WriteLine($"Data successfully saved to '{arguments[0]}'.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while writing the JSON file: {ex.Message}");
        }
    }
}
