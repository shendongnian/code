    class Program
        {
            static void Main(string[] args)
            {
                var input = 5;
                var options = new List<uint>();
    
                for (uint currentPow = 1; currentPow != 0; currentPow <<= 1)
                    if ((currentPow & input) != 0)
                        options.Add(currentPow);
    
                foreach (var option in options)
                    Console.WriteLine(option);
    
                Console.ReadLine();
            }
        }
