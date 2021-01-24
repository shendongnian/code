    class Program
    {
        static void Main(string[] args)
        {
            int value = 7;
    
            int copy = value; // only needed for the Console.WriteLine below
    
            var allComponents = new[] { 4, 2, 1 };
    
            var sumParts = new List<int>();
            int i = 0;
    
            while (i < allComponents.Length)
            {
                if (value >= allComponents[i])
                {
                    value -= allComponents[i];
                    sumParts.Add(allComponents[i]); // or do some action whatever you need
                }
                i++;
            }
    
            Console.WriteLine("Value {0} is the sum of {1}", copy, string.Join(" + ", sumParts));
        }
    }
