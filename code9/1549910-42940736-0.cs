            while (true)
            {
                Console.WriteLine("How many friends are there in total?");
                int amountOfPeople = int.Parse(Console.ReadLine());
                if (amountOfPeople < 1 || amountOfPeople > 100)
                {
                    Console.WriteLine("Input is not valid");
                    continue;
                }
                var friendsList = Enumerable.Range(1, amountOfPeople).ToList();
                Console.WriteLine("How many rounds of removal will there be?");
                int totalRounds = int.Parse(Console.ReadLine());
                if (amountOfPeople < 1 || amountOfPeople > 10)
                {
                    Console.WriteLine("Input is not valid");
                    continue;
                }
                for (int i = 0; i < totalRounds; i++)
                {
                    Console.WriteLine("Multiples to remove?");
                    int pick = int.Parse(Console.ReadLine());
                    friendsList.RemoveAll(x => x % pick == 0);
                }
                Console.WriteLine("\r\nHere are the guests\r\n");
                friendsList.ForEach(Console.WriteLine);                
            }
