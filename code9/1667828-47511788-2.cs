    public interface IEntity<out TKey>
    {
        TKey Id { get; }
    }
    public class Question<TPrimaryKey> : IEntity<int>
    {
         public TPrimaryKey Id { get; set; }
    }
