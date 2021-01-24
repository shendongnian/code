    try
    {
        db.table.DeleteOnSubmit(entity);
        db.SubmitChanges();
    }
    catch(Exception e)
    {
        Console.WriteLine(e);
        // Provide for exceptions.
    }
