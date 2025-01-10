using System.Text.RegularExpressions;

namespace PerfumeManager;

public class CommandInterpreter
{
    PerfumeManager perfumeManager;

    public CommandInterpreter(PerfumeManager perfumeManager)
    {
        this.perfumeManager = perfumeManager;
    }
    
    public Command Interpret(string[] arguments)
    {
        if (arguments.Length < 1)
        {
            Console.Error.WriteLine("Not enough arguments!");

            new NopCommand();
        }

        string commandName = arguments[0];
        string[] commandArguments = arguments.Skip(1).ToArray();

        switch (commandName)
        {
            case "add":
                return new AddCommand(perfumeManager, commandArguments);

            case "search":
                return new SearchCommand(perfumeManager, commandArguments);

            case "save":
                return new SaveCommand(perfumeManager, commandArguments);

            case "load":
                return new LoadCommand(perfumeManager, commandArguments);

            case "write_json":
                return new WriteJsonCommand(perfumeManager, commandArguments);

            case "read_json":
                return new ReadJsonCommand(perfumeManager, commandArguments);

            case "write_history":
                return new WriteHistoryCommand(perfumeManager, commandArguments);
            
            case "help":
                return new HelpCommand(perfumeManager, commandArguments);
            
            case "exit":
                return new ExitCommand(perfumeManager, commandArguments);

            default:
                throw new CommandNotFoundException($"The command '{commandName}' doesn't exist.");

        }
    }
}
