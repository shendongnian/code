    public interface IEntity
    {
        DateTime CreatedDate { get; set; }
    }
    public class MyEntity : IEntity
    {
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
    }
