    db.YourTable.Where(x => x.TheId == TheParameterId && x.AnotherColumn == true).ToList().ForEach(x =>
    {
        x.IsActive = false; x.UpdatedTimeStamp = DateTime.Now;
    });
    db.SaveChanges();
