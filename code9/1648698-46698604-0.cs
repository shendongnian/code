    static void printText(string textToPrint)
        {
            ConsoleKeyInfo cki;
            do
            {
                int x = 0;
                while (Console.KeyAvailable == false)
                {
                    Console.Write(textToPrint[x]);
                    System.Threading.Thread.Sleep(150);
                    x++;
                    if (x >= textToPrint.Length)
                        return;
                }
                cki = Console.ReadKey(true);
                Console.WriteLine(Environment.NewLine + textToPrint);
            } while (cki.Key != ConsoleKey.X);
            Console.ReadLine();
        }
