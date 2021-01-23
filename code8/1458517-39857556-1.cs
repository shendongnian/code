            Console.Write("Hi, if you wish to see a movie please enter your age: ");
            string AgeAsAString = Console.ReadLine();
            int Age = (int) Convert.ToInt32(AgeAsAString);
            List<Movie> ilist = new List<Movie>();
            ilist.Add(new Movie()
            {
                Name = "Buried",
                AgeRestriction = 18
            });
            ilist.Add(new Movie()
            {
                Name = "Despicable Me",
                AgeRestriction = 10
            });
            if (Age >= 18)
                return string.Join(",", ilist.Select(x => x.Name));
            else
                return string.Join(",", ilist.Where(x => x.AgeRestriction <= Age));
            
            Console.ReadKey();
