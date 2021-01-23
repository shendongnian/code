    public abstract class BaseEntity
    {
        public int Id {get;set;}
        public ObjectState ClientState { get;set; } = ObjectState.Unchanged;
        public bool IsNew => Id <= 0;
    }
