    public partial class myPocoClass : Entity
    {
    }
    public abstract class Entity : IObjectState
    {
        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }
