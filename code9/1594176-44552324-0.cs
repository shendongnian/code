                var group =
                    from c in lst
                    group c by new
                    {
                        c.Category
    
                    } into g
                    select new
                    {
                        Category = g.Key.Category,
                        Class = lst.Where(x => g.Key.Category == x.Category).Select(y => y.Class).ToList(),
                        Id = lst.Where(x => g.Key.Category == x.Category)
                                .Select(y => y.Id).ToList()
                    };
