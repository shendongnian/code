        static void Main(string[] args)
        {
            Console.WriteLine("Enter numbers separate by hypen : ");
            var name = Console.ReadLine();
            var numarray = name.Split('-');
            var lower = int.Parse(numarray[0]);
            Console.WriteLine(Enumerable.Range(lower, numarray.Length)
                .Select(z => z.ToString()).SequenceEqual(numarray)
                ? "Consecutive"
                : "Not");
            Console.ReadLine();
        }
