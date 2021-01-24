    namespace Loop
    {
        class Program
        {
            static void Main(string[] args)
            {
                int[] Numbers = new int[3];
    
                Numbers[0] = 101;
                Numbers[1] = 102;
                Numbers[2] = 103;
    
                int i = 0;
                while (i < Numbers.Length)
                {
                    Console.WriteLine("Numbers are: "+ Numbers[i]);
                    i++;
                   
                }
               Console.ReadKey();
            }
        }
    }
