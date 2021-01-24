    using (var db = new DataContext())
    {
        var new_list = from p in db.People
                       join c in db.Companies on p.Company.Id equals c.Id
                       select new { p, c };
    }
