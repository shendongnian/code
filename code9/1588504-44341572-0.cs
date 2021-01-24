        static void Main(string[] args)
        {
            Console.WriteLine("Enter numbers separate by hypen : ");
            var name = Console.ReadLine();
            var numarray = name.Split('-');
            var lower = int.Parse(numarray[0]);
            if (Enumerable.Range(lower, numarray.Length).Select(z => z.ToString()).SequenceEqual(numarray))
                Console.WriteLine("Consecutive");
            else
                Console.WriteLine("Not");
            Console.ReadLine();
