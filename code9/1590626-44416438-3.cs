    public interface IFooDTO
    {
       int Id { get; set;}
       string Name { get; set;}
    }
    public class FooDTO : IFooDTO
    {
       public int Id { get; set;}
       public string Name { get; set; }
    }
