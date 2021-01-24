    public sealed class Sublist
    {
        public int Start { get; set; }
        public int End   { get; set; }
        public List<double> Numbers { get; set; }
        public Sublist(int start, int end, List<double> numbers)
        {
            Start   = start;
            End     = end;
            Numbers = numbers;
        }
    }
