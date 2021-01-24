    public class Child
    {
        public int Id { get; set; }
        public virtual Parent ParentA { get; set; }
        public virtual Parent ParentB { get; set; }
        public Child() { }
    }
