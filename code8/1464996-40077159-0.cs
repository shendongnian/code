            string[] movies = {
                    "Star Wars Episode IV A New Hope",
                    "Force of Hunger",
                    "The Hunger Games Mockingjay",
                    "Jaws 2",
                    "The Shawshank Redemption",
                    "Hunger Pain",
                    "The Hunger Games",
                    "Jaws: The Revenge",
                    "The Hunger Games Catching Fire",
                    "Rogue One A Star Wars Story",
                    "Aqua Teen Hunger Force",
                    "The Force Awakens Star Wars",
                };
            string[] kw = { "Star", "Wars", "Force", "Hunger", "Games", "The", "Jaws" };
            var group  = movies.GroupBy(p => kw.Count(k => p.Contains(k))).OrderByDescending(p=> p.Key);
            StringBuilder sb = new StringBuilder();
            foreach (var g in group)
            {
              sb.AppendLine("Group : " + g.Key);
                foreach (var s in g)
                {
                    sb.AppendLine(s);
                }
            }
