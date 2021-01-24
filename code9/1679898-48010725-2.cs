    // Getting persons.
    var persons = db.Persons
                    .Where(p => p.ID <= 10) // any of your filtering condition on persons
                    .Select(p => new { p.ID, p.Name });
    // Left join with 'Cars' table
    var leftJoin1 = from p in persons
                    join c in db.Cars on p.ID equals c.PersonID into j
                    from c in j.Distinct().DefaultIfEmpty() // do you really need Distinct here?
                    select new
                            {
                                PersonID = p.ID,
                                PersonName = p.Name,
                                CarID = c.ID,
                                CarNumber = c.DocNumber
                            };
    // Second left join with 'AnotherCars' table
    var leftJoin2 = from l in leftJoin1
                    join ac in db.AnotherCars on l.PersonID equals ac.PersonID into j
                    from ac in j.Distinct().DefaultIfEmpty() // do you really need Distinct here?
                    select new
                            {
                                PersonID = l.PersonID,
                                PersonName = l.PersonName,
                                CarID = ac.ID,
                                CarNumber = l.PersonName == "Adam" ? ac.DocNumber : l.CarNumber // condition on PersonName
                            };
    // result query
    var result = leftJoin2.OrderBy(r => r.PersonID).ThenBy(r => r.CarID);
