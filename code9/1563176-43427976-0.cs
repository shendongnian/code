    var Drivers = new[] { new { Name = "Alex"  , Team = "Ferrari"  },
                          new { Name = "Peter" , Team = "Ferrari"  },
                          new { Name = "John"  , Team = "Mercedes" },
                          new { Name = "May"   , Team = "Toyota"   },
                          new { Name = "Hannah", Team = "Mercedes" } };
    var Winners = "Alex Peter Alex John May John Hannah".Split();
    var Teams = Winners.Join(Drivers, w => w, d => d.Name, (w, d) => d.Team);   // Ferrari, Ferrari, Ferrari, Mercedes, Toyota, Mercedes, Mercedes
    var Counts = Teams.Aggregate(new List<Tuple<int, string>>(), (L, t) => { L.Add(
        Tuple.Create(L.Any() && L.Last().Item2 == t ? L.Last().Item1 + 1 : 1, t)); return L; });   // (1, Ferrari), (2, Ferrari), (3, Ferrari), (1, Mercedes), (1, Toyota), (1, Mercedes), (2, Mercedes)
    var Max = Counts.Max();    // (3, Ferrari)
