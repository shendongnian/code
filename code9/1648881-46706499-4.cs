    dic1.Keys.Union(dic2.Keys).Union(dic3.Keys).Distinct().ToList().ForEach(id =>
                DoSomethingElse(
                    dic1.GetSafeValue(id) ?? new Thing(id),
                    dic2.GetSafeValue(id) ?? new List<Thing>(),
                    dic3.GetSafeValue(id) ?? new List<Thing>())
            );
