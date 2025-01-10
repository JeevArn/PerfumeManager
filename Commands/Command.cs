namespace PerfumeManager;

public abstract class Command
{
    protected PerfumeManager PerfumeManager;
    protected bool isValid = true;
    protected string[] arguments;

    public Command() { }

    public Command(PerfumeManager perfumeManager, string[] commandArguments)
    {
        PerfumeManager = perfumeManager;
        arguments = commandArguments;

        // Log the command execution for the WriteHistoryCommand
        PerfumeManager.LogCommand($"{GetType().Name} {string.Join(" ", arguments)}");
    }

    public abstract void Execute();
}