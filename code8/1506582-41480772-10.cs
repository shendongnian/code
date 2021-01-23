    public abstract class BaseEntity
    {
        public int Id {get;set;}
        [NotMapped]
        public ObjectState ClientState { get;set; } = ObjectState.Unchanged;
        [NotMapped]
        public bool IsNew => Id <= 0;
    }
