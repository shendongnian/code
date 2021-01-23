              Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int k = 0; k < 1000000; k++)
            {
                // heinzbeinz
                var petLists = pets.GroupBy(i => i.GetType()).Select(g => g.ToList()).ToList();
            }
            sw.Stop();
            Console.WriteLine($"Time taken using heinzbeinz: {sw.ElapsedMilliseconds}");
            sw.Reset();
            sw.Start();
            for (int k = 0; k < 1000000; k++)
            {
                // Arturo Menchaca
                var dogs = pets.OfType<Dog>().ToList();
                var cats = pets.OfType<Cat>().ToList();
                var parrots = pets.OfType<Parrot>().ToList();
            }
            sw.Stop();
            Console.WriteLine($"Time taken using Arturo Menchaca: {sw.ElapsedMilliseconds}");
            sw.Reset();
            sw.Start();
            for (int k = 0; k < 1000000; k++)
            {
                // johnny 5
                var dogs = pets.Where(x => x is Dog).ToList();
                var cats = pets.Where(x => x is Cat).ToList();
                var parrots = pets.Where(x => x is Parrot).ToList();
            }
            sw.Stop();
            Console.WriteLine($"Time taken using johnny 5: {sw.ElapsedMilliseconds}");
            sw.Reset();
            sw.Start();
            for (int k = 0; k < 1000000; k++)
            {
                // Matt Clark
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
            Console.WriteLine($"Time taken using Matt Clark (no linq): {sw.ElapsedMilliseconds}");
