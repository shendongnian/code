    // Getting persons.
    var persons = db.Persons
                    .Where(p => p.ID <= 10) // any of your filtering condition on persons
                    .Select(p => new { p.ID, p.Name });
    // Left join with 'Cars' table
    var leftJoin1 = from p in persons.Where(p => p.Name != "Adam")
                    join c in db.Cars on p.ID equals c.PersonID into j
                    from c in j.Distinct().DefaultIfEmpty() // do you really need Distinc here?
                    select new
                           {
                               PersonID = p.ID,
                               PersonName = p.Name,
                               CarID = c.ID,
                               CarNumber = c.DocNumber
                           };
    // Left join with 'AnotherCars' table
    var leftJoin2 = from p in persons.Where(p => p.Name == "Adam")
                    join ac in db.AnotherCars on p.ID equals ac.PersonID into j
                    from ac in j.Distinct().DefaultIfEmpty() // do you really need Distinc here?
                    select new
                           {
                               PersonID = p.ID,
                               PersonName = p.Name,
                               CarID = ac.ID,
                               CarNumber = ac.DocNumber
                           };
    // Resul query
    var result = leftJoin1.Concat(leftJoin2)
                          .OrderBy(r => r.PersonID)
                          .ThenBy(r => r.CarID)
                          .ToList();
