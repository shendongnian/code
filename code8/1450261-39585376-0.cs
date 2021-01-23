    List<Product> res = new List<Product>();
    for (int i = 0; i < lst.Count(); i++)
    {
        res.AddRange(lst.Where(p => p.Desription.Contains("top").ToList());
        res.AddRange(lst.Where(p => p.Desription.Contains("medium").ToList());
        res.AddRange(lst.Where(p => p.Desription.Contains("bottom").ToList());
    }
