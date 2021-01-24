    public abstract class Command
    {
        public abstract bool IsComplete { get; }
        public abstract void Execute();
    }
    public static class CommandExecutor
    {
        public static Queue<Command> commands;
        public static Command current;
        
        public static void Update()
        {
            if (commands.Count > 0
                && (current == null || current.IsComplete))
            {
                current = commands.Dequeue();
                current.Execute();
            }
        }
    }
