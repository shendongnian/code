    //Get the database entry
    var entity = db.Person.First(c=>c.ID == 1);
    //OR
    //Attach a object to the context, see Nsevens answer.
    db.Person.Attach(entity);
    //Change a property
    entity.Job = "Accountant";
    //State it's a modified entry
    db.Entry(entity).State = EntityState.Modified;
    //Save
    db.SaveChanges();
