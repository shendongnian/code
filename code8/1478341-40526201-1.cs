    static void Main(string[] args)
        {
            List<Example> samples = new List<Example>();
            samples.Add(new Example(1, DateTime.Parse("2016-10-11"), 1, 10.5));
            samples.Add(new Example(2, DateTime.Parse("2016-10-11"), 1, 10.8));
            samples.Add(new Example(3, DateTime.Parse("2016-10-11"), 2, 10.1));
            samples.Add(new Example(4, DateTime.Parse("2016-10-11"), 2, 10.0));
            samples.Add(new Example(5, DateTime.Parse("2016-10-12"), 1, 11.1));
            samples.Add(new Example(6, DateTime.Parse("2016-10-12"), 1, 11.7));
            samples.Add(new Example(7, DateTime.Parse("2016-10-12"), 2, 11.9));
            samples.Add(new Example(8, DateTime.Parse("2016-10-12"), 2, 11.6));
            var daily_results = samples.GroupBy(g => new { g.group, g.date }).GroupBy(g => g.Key.date);
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            foreach (var group_result in daily_results)
            {
                sb.Append("[");
                foreach(var result in group_result)
                {
                    sb.Append($"[{string.Join(",", result.OrderBy(r => r.value).Select(r => r.value))}]");
                }
                sb.Append("]");
            }
            sb.Append("]");
            Console.WriteLine(sb);
            Console.Read();
        }
    }
    class Example
    {
        public int id;
        public DateTime date;
        public int group;
        public double value;
        public Example(int i, DateTime d, int g, double v)
        {
            id = i;
            date = d;
            group = g;
            value = v;
        }
    }
