             Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int k = 0; k < 1000000; k++)
            {
                // heinz
                var petLists = pets.GroupBy(i => i.GetType()).Select(g => g.ToList()).ToList();
            }
            sw.Stop();
            Console.WriteLine($"Time taken using linq: {sw.ElapsedMilliseconds}");
            sw.Reset();
            sw.Start();
            for (int k = 0; k < 1000000; k++)
            {
                // me
                var dogs = new List<Dog>();
                var cats = new List<Cat>();
                var parrot = new List<Parrot>();
                foreach (var pet in pets)
                {
                    if (pet is Dog)
                    {
                        dogs.Add(pet as Dog);
                    }
                    if (pet is Cat)
                    {
                        cats.Add(pet as Cat);
                    }
                    if (pet is Parrot)
                    {
                        parrot.Add(pet as Parrot);
                    }
                }
            }
            sw.Stop();
            Console.WriteLine($"Time taken using no linq: {sw.ElapsedMilliseconds}");
