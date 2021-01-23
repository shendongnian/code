            List<Server> serversList = new List<Server>();
            serversList.Add(new Server { Name = "S1", Location = "LOC1", Distance = 3, Load = null });
            serversList.Add(new Server { Name = "S2", Location = "LOC1", Distance = 3, Load = 1 });
            serversList.Add(new Server { Name = "S3", Location = "LOC1", Distance = 3, Load = 6 });
            serversList.Add(new Server { Name = "S4", Location = "LOC1", Distance = 3, Load = 2 });
            serversList.Add(new Server { Name = "S1", Location = "LOC2", Distance = 1, Load = 7 });
            serversList.Add(new Server { Name = "S2", Location = "LOC2", Distance = 1, Load = 1 });
            serversList.Add(new Server { Name = "S3", Location = "LOC2", Distance = 1, Load = 2 });
            serversList.Add(new Server { Name = "S1", Location = "LOC3", Distance = 2, Load = 1 });
            List<Server> orderedList = new List<Server>();
            var serversByDistance = serversList.Where(x => x.Load != null)
                .OrderBy(x => x.Distance)
                .GroupBy(x => x.Distance)
                .ToDictionary(x => x.Key, x => x.OrderBy(s => s.Load).ToList());
            for (int i = 0; i < serversByDistance.Values.Max(x => x.Count); i++)
            {
                foreach (var key in serversByDistance.Keys)
                {
                    var element = serversByDistance[key].ElementAtOrDefault(i);
                    if (element != null)
                        orderedList.Add(element);
                }
            }
