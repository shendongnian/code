    foreach (var item in db.ISVCSP.Where(s => s.BeneficiaryId == beneficiaryId))
    {
        item.IsDeleted = true;    
    }
    await db.SaveChangesAsync();
