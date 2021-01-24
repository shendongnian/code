    public class Script
    {
        public Script(int from, int to, string name)
        {
            From = from;
            To = to;
            Name = name;
        }
    
        public int From { get; }
        public int To { get; }
        public string Name { get; }
    
        public bool Contains(char c) => From <= (int) c && (int) c <= To;
    }
