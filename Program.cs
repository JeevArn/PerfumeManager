namespace PerfumeManager;

public class Program
{
    public static void Main(string[] args)
    {
        PerfumeManager perfumeManager = new PerfumeManager();
        CommandInterpreter interpreter = new CommandInterpreter(perfumeManager); 

        while (true)
        {
            Console.Write("$ ");
            string line = Console.ReadLine();
            string[] commandArgs = line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries); 

            try
            {
                Command command = interpreter.Interpret(commandArgs); 
                command.Execute();
            }
            catch (CommandNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

