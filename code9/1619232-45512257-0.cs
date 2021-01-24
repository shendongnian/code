    > public class AClass { public string A { get; set; } public int B { get; set; } }
    > public class BClass { public string A { get; set; } public int C { get; set; } }
    > var x = new List<AClass> { new AClass { A = "a", B = 1 }, new AClass { A = "B", B = 2 } };
    > var y = new List<BClass> { new BClass { A = "C", C = 3 }, new BClass { A = "D", C = 4 } };
    > var z = (from item in x select new { A = item.A, B = item.B }).Union(from item in y select new { A = item.A, B = item.C });
    > z
    UnionIterator { \{ A = "a", B = 1 }, \{ A = "B", B = 2 }, \{ A = "C", B = 3 }, \{ A = "D", B = 4 } }
