    public class MyDBContext : DbContext, IUnitOfWork
    {
        public void Commit()
        {
            SaveChanges();
        }
        public int SaveChanges()
        {
             //see below
            SetIsolationLevel();
            base.SaveChanges();
        }
    }
