    public interface IActive
    {
        public bool Active {get;set;}
    }
    
    public class MyClass : IActive
    {
        public int Id {get;set;}
        public bool Active {get;set;}
    }
    
    protected override void OnModelCreating(DbModelBuilder modelBuilder) 
    {   
        modelBuilder.Conventions
           .Add(FilterConvention.Create<IActive, bool>("MyFilter", (entity, Active) => entity.Active);
    }
