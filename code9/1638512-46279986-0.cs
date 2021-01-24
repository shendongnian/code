            System.Numerics.BigInteger i = 2;
            Console.ForegroundColor = ConsoleColor.Green;
            while (true)
            {
                Console.WriteLine(i);
                i = i * i;
                Thread.Sleep(500);
            }
