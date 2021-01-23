    try{
           db.SaveChanges();
    }
    catch (DbEntityValidationException vex)
    {
           // Write to log file if you have logging support 
           Debug.WriteLine(HandleDbEntityValidationException(vex));
           throw;
    }
    catch (DbUpdateException dbu)
    {
           // Write to log if you have logging support
           Debug.WriteLine( HandleDbUpdateException(dbu));
           throw;
    }
