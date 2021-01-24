    public abstract class MyBaseClass
    { 
        [NotMapped]
        public MyEnum MyEnum { get; protected set; }
    }
    
    public class MyDbContext : DbContext
    {
        DbSet<MyBaseClass> MyBaseClass { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
    
            modelBuilder.Entity<MyBaseClass>()
                .Map<DerivedOne>(x => x.Requires("MyEnum").HasValue((int)MyEnum.Value1))
                .Map<DerivedTwo>(x => x.Requires("MyEnum").HasValue((int)MyEnum.Value2));
        }
    }
    
    static void Main(string[] args)
    {
        var db = new MyDbContext();
    
        var derivedOne = new DerivedOne();
    
        derivedOne.MyDerivedOneString = "test";
    
        db.MyBaseClass.Add(derivedOne);
        
        db.SaveChanges();
        var test = db.MyBaseClass.OfType<DerivedOne>().FirstOrDefault();
    }
