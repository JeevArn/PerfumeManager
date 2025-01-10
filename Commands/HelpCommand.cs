namespace PerfumeManager;

public class HelpCommand : Command
{
    private readonly Dictionary<string, string> CommandDescriptions = new Dictionary<string, string>
    {
        { "add", "Adds a new perfume. Usage: add <id> <name> <brand> <note,note> <scentprofile>" },
        { "load", "Loads perfumes from a CSV file. Usage: load <filepath>" },
        { "save", "Saves perfumes to a CSV file. Usage: save <filepath>" },
        { "search", "Searches perfumes based on criteria (id, name, brand, note, scentprofile). Usage: search <criterion> <value>" },
        { "write_json", "Writes the current state of perfumes to a JSON file. Usage: write_json <filepath>" },
        { "read_json", "Loads perfumes from a JSON file. Usage: read_json <filepath>" },
        { "write_history", "Writes the command history to a TXT file. Usage: write_history <filepath>" },
        { "exit", "Exits the application. Usage: exit" },
        { "help", "Displays the list of available commands and their usage. Usage: help" }
    };

    public HelpCommand(PerfumeManager perfumeManager, string[] commandArguments)
        : base(perfumeManager, commandArguments)
    {
    }

    public override void Execute()
    {
        Console.WriteLine("Available Commands:");
        foreach (var command in CommandDescriptions)
        {
            Console.WriteLine($"- {command.Key}: {command.Value}");
        }
    }
}
