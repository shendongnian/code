    private static void Main(string[] args)
        {
            string example = "\"Hello World, My name is Gumpy!\",20,male;My sister's name is Amy,29,female";
            var result1 = example.Split(';')
                                 .Select(s => s.Split('"'))
                                 .Select(sl => sl.Select((ss, index) => index % 2 == 0 ? ss.Split(',') : new string[] { ss }))
                                 .Select(sl => sl.SelectMany(sc => sc)
                                                 .Where(sc => !string.IsNullOrWhiteSpace(sc)));
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
