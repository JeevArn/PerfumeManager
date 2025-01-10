using System.IO;

namespace PerfumeManager;

// Writes the command execution history in a txt file
public class WriteHistoryCommand : Command
{

    public WriteHistoryCommand(
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
            Console.Error.WriteLine("Invalid arguments. Usage: writehistory <txtfilepath>");
            return;
        }
        string txtfilepath = $"{arguments[0]}";

        try
        {
            // Retrieve the command history
            List<string> history = PerfumeManager.GetHistory();

            if (history == null || history.Count == 0)
            {
                Console.WriteLine("No history to save.");
                return;
            }

            // Write the history to the file
            File.WriteAllLines(txtfilepath, history);

            Console.WriteLine($"History successfully saved to '{txtfilepath}'.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred while writing the history file: {ex.Message}");
        }
    }
}
