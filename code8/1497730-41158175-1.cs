    [AttributeUsage(AttributeTargets.Class)]
    public sealed class CommandExecutorAttribute : Attribute
    {
        public CommandExecutorAttribute(Type commandType)
        {
            CommandType = commandType;
        }
        public Type CommandType { get; }
        // ...
    }
    [CommandExecutor(typeof(Command1))]
    public sealed class Command1Executor : ICommandExecutor
    {
        // ...
    }
    List<CommandResult> Execute(List<CommandBase> commands)
    {
        return commands
            .Select(command =>
            {
                // obtain executor types somehow, e.g. using DI-container or
                // using reflection;
                // inspect custom attribute, which matches command type
                var executorType = ....
                var executor = Activator.CreateInstance(executorType , command);
                return executor.Execute();
            })
            .ToList();
    }
