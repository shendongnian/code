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
