    public abstract class ObjectWithId
    {
        public int Id { get; set; }
    }
    public class ObjectThatRelates<T> : ObjectWithId
        where T : ObjectWithId
    {
        public int OtherId { get; set; }
        public IEnumerable<T> Similar { get; set; }
    }
    public class Object1 : ObjectWithId
    {
        public ObjectThatRelates<Object1> { get; set; }
    }
    public class Object2 : ObjectWithId
    {
        public ObjectThatRelates<Object2> { get; set; }
    }
