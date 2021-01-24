    public class CommandBase<T>
    {
        public CommandBase()
        {
            this.CommandText = typeof(T).Name; 
        }
        public String CommandText { get; }
    }
