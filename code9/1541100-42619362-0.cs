        static void Main(string[] args)
        {
            string all = @"John William Doe 250 / 1000 Adam Smith 500 / 1000 Jane Black 250 / 1000";
            Regex r = new Regex(@"(?:\w+\s+)+\d+\s+/\s+\d+");
            foreach (Match m in r.Matches(all))
            {
                Console.WriteLine(m.Groups[0]);
            }
            Console.ReadLine();
        }
