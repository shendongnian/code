            static void Main(string[] args)
            {
                string[] test = {"0", "1", "2", "3"};
                int output = test.Select(s => Convert.ToInt32(s)).ToArray().Aggregate((x, y) => x + y);
                Console.WriteLine(output);
    
            }
