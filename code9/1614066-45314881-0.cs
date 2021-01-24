    public class SomeContext : DbContext
    {
        public SomeContext()
            : base("name=SomeContext")
        {
        }
        public virtual DbSet<article> Articles { get; set; }
        public virtual DbSet<adjective> Adjectives { get; set; }
    }
    public abstract class baseGrammar
    {
        //... common properties/columns
    }
    public class article : baseGrammar
    {
    }
    public class adjective : baseGrammar
    {
    }
