    public static void Main()
        {
            ExecutionComposite composite = new ExecutionComposite(new ExecutionInfo() {CommandName = string.Empty});
            composite.Add(new ExecutionOne(new ExecutionInfo() {CommandName = "Command (Line 1)"}));
            composite.Add(new ExecutionOne(new ExecutionInfo() {CommandName = "Command (Line 2)"}));
            ExecutionComposite composite1 = new ExecutionComposite(new ExecutionInfo() {CommandName = "Loop (Line 3)"});
            composite.Add(composite1);
            composite1.Add(new ExecutionOne(new ExecutionInfo() {CommandName = "Command (Line 4)"}));
            composite1.Add(new ExecutionOne(new ExecutionInfo() {CommandName = "Command (Line 5)"}));
            ExecutionComposite composite2 = new ExecutionComposite(new ExecutionInfo() { CommandName = "Loop (Line 5)" });
            composite1.Add(composite2);
            composite2.Add(new ExecutionOne(new ExecutionInfo() { CommandName = "Command (Line 6)" }));
            composite2.Add(new ExecutionOne(new ExecutionInfo() { CommandName = "Command (Line 7)" }));
            composite.Add(new ExecutionOne(new ExecutionInfo() {CommandName = "Command (Line 8)"}));
            composite.Add(new ExecutionOne(new ExecutionInfo() {CommandName = "Command (Line 9)"}));
            composite.Print("--");
            Console.ReadLine();
        }
    }
    public interface IExection
    {
        ExecutionInfo Info { get; }
        void Print(string indent);
    }
    public class ExecutionComposite : IExection
    {
        List<IExection> executions = new List<IExection>();
        public ExecutionInfo Info { get; }
        public ExecutionComposite(ExecutionInfo executionInfo)
        {
            Info = executionInfo;
        }
        public void Add(IExection one)
        {
            executions.Add(one);
        }
        public void Remove(IExection one)
        {
            if (executions.Contains(one))
            {
                executions.Remove(one);
            }
        }
        public void Print(string indent)
        {
            indent += "\t";
            foreach (var exe in executions)
            {
                exe.Print(indent);
            }
        }
    }
    public class ExecutionOne : IExection
    {
        public ExecutionInfo Info { get; }
        public ExecutionOne(ExecutionInfo executionInfo)
        {
            Info = executionInfo;
        }
        public void Print(string indent)
        {
            Console.WriteLine("{0}{1}", indent, Info.CommandName);
        }
    }
    public class ExecutionInfo
    {
        //the Execution Info class contains information about the command
        public string CommandName { get; set; }
    }
