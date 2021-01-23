    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter amount of tries"); // typo
            int TryCount = Convert.ToInt32(Console.ReadLine());
    
            Random numgen = new Random();
    
            // it is sum we compute in the loop (add up values), not average
            // double: final average will be double: say 2 tries 4 and 5 -> 4.5 avg
            // please notice, that sum is declared out of the loop's scope 
            double sum = 0.0; 
    
            // for loop looks much more natural in the context then while one
            for (int i = 0; i < TryCount; ++i)
              sum += numgen.Next(1, 6);
    
            // we want to compute the average, right? i.e. sum / TryCount
            Console.WriteLine(sum / TryCount);
            Console.ReadLine();
        }
    }
