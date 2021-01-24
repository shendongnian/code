            List<Team> list = new List<Team>();
            Team team = new Team();
            team.Name = "0";
            list.Add(team);
            for (int i = 1; i < 200000; i++)
            {
                team = new Team();
                team.Name = i.ToString();
                team.ParentTeam = list.Last();
                list.Add(team);
            }
            list.Reverse();
            Console.WriteLine("Order List of " + list.Count +" teams");
            Console.WriteLine("order is " + (TestOrder(list) ? "ok" : "ko"));
            list.Shuffle();
            Console.WriteLine("Shuffled List");
            Console.WriteLine("order is " + (TestOrder(list) ? "ok" : "ko"));
            DateTime start = DateTime.Now;
            var res = list.FindDescendandOptimized(null);
            list = res.ToList();
            DateTime end = DateTime.Now;
            Console.WriteLine("Reordered List");
            Console.WriteLine("order is " + (TestOrder(list) ? "ok" : "ko"));
            Console.WriteLine("Benchmark ms: " + (end - start).TotalMilliseconds);
            Console.ReadLine();
