    public class Store
    {
        public virtual int Id { get; protected set; }
        public virtual IList<Store> Competitors { get; set; }
    }
