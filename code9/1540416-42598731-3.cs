    var existing = db.Borrowers.Include(e => e.BorrowerIndividual).FirstOrDefault(e => e.Id == entity.Id);
    db.Entry(existing).CurrentValues.SetValues(entity);
    if (existing == null) return; // ??
    if (existing.BorrowerIndividual != null && entity.BorrowerIndividual != null)
    {
    	entity.BorrowerIndividual.Id = existing.Id;
    	db.Entry(existing.BorrowerIndividual).CurrentValues.SetValues(entity.BorrowerIndividual);
    }
    else
    	existing.BorrowerIndividual = entity.BorrowerIndividual;
    db.SaveChanges();
