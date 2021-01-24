        void DoSomething(Dictionary<ThingId, Thing> dic1, Dictionary<ThingId, List<Thing>> dic2, Dictionary<ThingId, List<Thing>> dic3) // only 3 to not clutter the code
        {
             dic1.Keys.Union(dic2.Keys).Union(dic3.Keys).Distinct().ToList().ForEach(id =>
                DoSomethingElse(
                    dic1.FirstOrDefault(d => d.Key == id)?.Value ?? new Thing(id),
                    dic2.FirstOrDefault(d => d.Key == id)?.Value ?? new List<Thing>(),
                    dic3.FirstOrDefault(d => d.Key == id)?.Value ?? new List<Thing>())
            );
        }
