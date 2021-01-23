    // T generic parameter must inherit EventBase<T>
    public class EventBase<T>
        where T : EventBase<T>
    {
        public virtual T Parent { get; set; }
    
        [ForeignKey("Parent")]
        public virtual ICustomList<T> ChildList { get; set; } = new CustomList<T>()
    }
