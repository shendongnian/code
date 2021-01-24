    using (var db = new PartnerDBContext())
    {
        db.Persons.Add(personToInsert);
        foreach (var company in personToInsert.OwnedCompanies)
            db.Entry(company).State = EntityState.Unchanged;
        db.SaveChanges();
    }
