        using (var db = new DbContext())
            {
                var query = (from n in db.BDatas
                            orderby n.AddDate,n.CountryCode
                            where n.CountryCode=="GB" 
                            select n).Where(n => n.AddDate.Date >= stdate.Date &&
     n.AddDate.Date <= etdate).ToList();
            }
