    for (int a = 10; a >= 0; a--)
                {
                    Console.SetCursorPosition(0, 2);
                    Console.Write("Generating Preview in {0} ", a);  // Override complete previous contents
                    System.Threading.Thread.Sleep(10000);
                }
