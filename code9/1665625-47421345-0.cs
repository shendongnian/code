    public class MyDbContext : DbContext 
    {
    ...
    public override int SaveChanges()
        try
    {
          base.SaveChanges();
    }
    catch (DbEntityValidationException e)
    {
     foreach (var eve in e.EntityValidationErrors)
     {
        Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State);
        foreach (var ve in eve.ValidationErrors)
        {
              Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
       }
    }
    }
