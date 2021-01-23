    internal sealed class TestContext : DbContext
    {
        protected ObjectContext ObjectContext => ((IObjectContextAdapter)this).ObjectContext;
        
        public override int SaveChanges()
        {
            //detect all changes in context
            ChangeTracker.DetectChanges();
            //write changes to database
            var result = ObjectContext.SaveChanges(System.Data.Entity.Core.Objects.SaveOptions.None);
            //do some actions with entities
            DoStuff();
            //accept all changes in entities
            ObjectContext.AcceptAllChanges();
            return result;
        }
