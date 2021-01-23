    public interface IEntity
    {
        string PropertyA { get; set; }
        string PropertyB { get; set; }
    }
    public class EntityA : IEntity {
        public string PropertyA { get; set; }
        public string PropertyB { get; set; }
    }
    public class EntityB : IEntity
    {
        public string PropertyA { get; set; }
        public string PropertyB { get; set; }
    }
