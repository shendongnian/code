    namespace Test
    {
        class Program
        {
            static void Main(string[] args)
            {
    
    
                if (number(1, 9) == 1) // number is a function, not a variable
                {
                    // Do Stuff
                }
    
            }
    
            static int number(int min, int max)
            {
                Random random = new Random();
                return random.Next(min, max);
            }
        }
    }
