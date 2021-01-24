    private static void Main(string[] args)
        {
            string example = "\"Hello World, My name is Gumpy!\",20,male;My sister's name is Amy,29,female";
            var result1 = example.Split(';')
                                 .Select(s => s.Split('"')) // This will leave anything in abbreviation marks at odd numbers
                                 .Select(sl => sl.Select((ss, index) => index % 2 == 0 ? ss.Split(',') : new string[] { ss })) // if it's an even number split by a comma
                                 .Select(sl => sl.SelectMany(sc => sc)
                                                 .Where(sc => !string.IsNullOrWhiteSpace(sc))); // multiple arrays created for each line, merge and get rid of any whitespace
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
