     CurrentItems.Where(o=> o.UpdatedTime < DateTime.Parse("2001-08-02")
       .GroupBy(z=>z.Company)
       .Select(z=> new
       {
           Name=z.Key, 
           Summa=z.Where(i => i.Status == 1).Count() - z.Where(i => i.Status == 3).Count()
       });
