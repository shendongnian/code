    class Program
    {
        static void Main(string[] args)
        {
            var input = @"your long multiline string...";
            var list = new List<string>();
            var lines = input.Split('\n');
            var index = 0;
            var batchSize = 15000;
            while (index < lines.Count())
            {
                list.Add(string.Join(string.Empty, lines.Skip(index).Take(batchSize)));
                index += batchSize;
            }
        }
    }
