    Context.People.Attach(person);
    // Disable validation otherwise you can't do a partial update
    Context.Configuration.ValidateOnSaveEnabled = false;
    Context.Entry(person).Property(x => x.AddressId).IsModified = true;
    Context.Entry(person).Property(x => x.Birthday).IsModified = true;
    Context.Entry(person).Property(x => x.Name).IsModified = true;
    ...
    await Context.SaveChangesAsync();
