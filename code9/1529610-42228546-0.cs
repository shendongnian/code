    [Flags]
    public enum Status
    {
        Nominal = 1,
        Modified = 2,
        DirOneOnly = 4,
        DirTwoOnly = 8,
        DirOneNewest = 16,
        DirTwoNewest = 32
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Status s = new Status();
            s |= Status.Modified;
            if (s.HasFlag(Status.Modified))
            {
                Console.WriteLine("Modified!");
            }
        }
    }
