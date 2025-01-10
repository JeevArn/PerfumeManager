namespace PerfumeManager;

public class ExitCommand : Command
{
    public ExitCommand(PerfumeManager perfumeManager, string[] commandArguments)
        : base(perfumeManager, commandArguments)
    {
    }

    public override void Execute()
    {
        Console.WriteLine("Goodbye!");
        Environment.Exit(0);
    }
}
