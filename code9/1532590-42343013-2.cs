    public class JunctionModel : DbContext {
      public virtual DbSet<Foo_Bar> Foo_Bar { get; set; }
      public JunctionModel()
        : base("name=DatabaseConnection") {
      }
    }
