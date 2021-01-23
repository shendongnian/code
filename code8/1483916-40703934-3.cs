    public partial class MyContextEx : MyContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            throw new UnintentionalCodeFirstException();
        }
    }
