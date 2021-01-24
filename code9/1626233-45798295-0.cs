    namespace LoopTest
        {
            class Program
            {
                private static int WriteToConsole(int numberOfWrites)
                {
                    for (int i = numberOfWrites; i <= 10; i = WriteToConsole(i + 1))
                    {
                        Console.WriteLine("Looped {0} times.", i);
                    }
                    return numberOfWrites;
                }
                static void Main(string[] args)
                {
                    WriteToConsole(8);
                    Console.ReadKey();
                }
            }
        }
