      class Program
    {
        static void Main(string[] args)
        {
            const string inputstring = "Hello World";
            var count = 0;
            var charGroups = (from s in inputstring
                              group s by s into g
                              select new
                              {
                                  c = g.Key,
                                  count = g.Count(),
                              }).OrderBy(c => c.count);
            foreach (var x in charGroups)
            {
                Console.WriteLine(x.c + ": " + x.count);
                count = x.count;
            }
            Console.Read();     
          
        }
    }
