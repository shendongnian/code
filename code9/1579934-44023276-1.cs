    var As = new List<A> { new A { Id = 1 }, new A { Id = 2 }, new A { Id = 3 }, new A { Id = 4 } };
    var Bs = new List<B> { new B { Id = 1 }, new B { Id = 2 } };
    var set = new HashSet<int>(Bs.Select(b => b.Id));
    var filtered = from a in As
                   where !set.Contains(a.Id)
                   select a;
    // of course, only convert when it's used to get lazy evaluation benefit.
    As = filtered.ToList();
    // If As has unique Ids
    var dictA = As.ToDictionary(a => a.Id, a => a);
    foreach (var b in Bs)
    {
       if (dictA.ContainsKey(b.Id))
            dictA.Remove(b.Id);
    }
    // either use dictA or if really have to convert back to a list
    As = dictA.Values.ToList();
