        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    Console.WriteLine(i);
                    if (i == 3)
                        break;
                }
                catch (Exception e)
                {
                }
                finally
                {
                    Console.WriteLine("finally");
                }
            }
            Console.ReadKey();
        }
