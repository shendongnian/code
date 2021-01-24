    interface ICommand
    {
        object Context { get; set; }
        bool IsResponsible(string line);
        void Execute(string line);
    }
    public class Move: ICommand
    {
        public bool IsResponsible(string line)
        {
            return line.StartsWith("move");
        }
        public void Execute(string line)
        {
            var tmp = line.Split(',');
            // Validate and verify parameters here
            // code here to move the context to x/y 999.9
            // Context.Move(tmp[1], Convert.ToDouble(tmp[2]);
        }
    }
    public class Wait: ICommand
    {
        public bool IsResponsible(string line)
        {
            return line.StartsWith("wait");
        }
        public void Execute(string line)
        {
            var tmp = line.Split(',');
            // code here to wait...
        }
    }
