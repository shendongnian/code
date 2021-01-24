    class Program
    {
        static void Main(string[] args)
        {
             string[] testdata = { "one", "two", "three", "four"};
             ListCheckFunction(testdata);
             Console.ReadLine();
        }
        static void ListCheckFunction(string[] countries)
        {
            foreach (string country in countries)
            {
                int townCount = countries.Count();
                int i = 0;
                for (i = 0; i < townCount; i++)
                {
                    Console.WriteLine(country + " " +i);
                }
                Console.WriteLine(i + " i is still in scope");
            }
        }
    }
