        public int start;
        public int end;
        public Interval() { start = 0; end = 0; }
        public Interval(int s, int e) { start = s; end = e; }
    } 
    public static void DisplayInterval(Interval inter)
    {
        Console.Write(" [{0},{1}]",inter.start,inter.end);
    }
    public static void DisplayList<T>(IList<T> list)
    {
        foreach (T element in list)
        {
            if (element.GetType() == typeof(Interval))
                DisplayInterval((Interval)element);
            else
                Console.WriteLine(element);
        }
    }
