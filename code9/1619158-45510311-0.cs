      var tickCount = Environment.TickCount;
            var random = new Random();
            var seededRandom = new Random(tickCount);
            for (int i = 0; i < 100000000; i++)
            {
                // Does not enter the if case at any point.
                if (random.Next() != seededRandom.Next())
                {
                    Console.WriteLine("No match");
                }
            }
