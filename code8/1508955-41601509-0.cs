    public abstract class Parent<TEntity>
    {
        public int EntityId { get; set; }
        public TEntity Entity { get; set; }
    }
    
    public class Child : Parent<Foo>
    {
    }
    
    public class OtherChild : Parent<Bar>
    {
    }
    
    public class Foo
    {
        public int Id { get; set; }
    }
    
    public class Bar
    {
        public int Id { get; set; }
    }
