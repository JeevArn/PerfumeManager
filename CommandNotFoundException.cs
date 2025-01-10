namespace PerfumeManager;

public class CommandNotFoundException : Exception
{
    public CommandNotFoundException() 
        : base()
    {
    }

    public CommandNotFoundException(string message)
        : base(message)
    {
    }
}