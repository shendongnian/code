    public class Parent
    {
        public int ParentId {get; set;}
        public string Name {get; set;}
        public virtual ICollection<Child> Children {get; set;}
    }
    public class Child
    {
        public int ChildId {get; set;}
        public string Name {get; set;}
        // By convention will become the foreign key to Parent:
        public int ParentId {get; set;}
        public virtual Parent Parent {get; set;}
    }
    public class MyDbContext : DbContext
    {
        public DbSet<Parent> Parents {get; set;}
        public DbSet<Child> Children {get; set;}
    }
    public void Main()
    {
        using (var dbContext = new MyDbContext(...))
        {
            var addedParent = dbContext.Parents.Add(new Parent()
            {
                 Name = "Phil Dunphy",
            }
            // if you do not want to add a child now, you can SaveChanges
            dbContext.SaveChanges();
            // now addedParent has a ParentId, you can add a child:
            var addedChild = dbContext.Children.Add(new Child()
            {
                Name = "Luke Dunphy",
                ParentId = addedParent.Id,
            };
            dbContext.SaveChanges();
        }
    }
