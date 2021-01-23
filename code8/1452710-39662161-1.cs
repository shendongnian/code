    public partial class RBSYNERGYEntities : DbContext
        {
            //Other is ommited 
            public override int SaveChanges()
            {
                var changedEntities = ChangeTracker.Entries();
                foreach (var changedEntity in changedEntities)
                {
                    if (changedEntity.State == System.Data.Entity.EntityState.Deleted)
                    {
                        tblProductMaster info = changedEntity.Entity as tblProductMaster;
                        if (info != null)
                        {
                            //Do your work here
                            int a = 0;
                        }
                    }
                }
    
                return base.SaveChanges();
            }
        }
