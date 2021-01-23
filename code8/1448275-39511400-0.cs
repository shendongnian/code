    var L = Enumerable.Range(0, 10).ToList();
    L = L.Where(i => (i & 1) > 0).ToList();
    //L = Enumerable.Range(0, L.Count / 2).Select(i => L[(i << 1) + 1]).ToList(); 
    //L = Enumerable.Range(0, L.Count).Where(i => (i & 1) > 0).Select(i => L[i]).ToList();
    //L.RemoveAll(i => (i & 1) == 0); // { 1, 3, 5, 7, 9 }
