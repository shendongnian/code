    public class Child
    {
        public int ChildId {get; set;}
        public int ParentId {get; set;}
        public virtual Parent Parent {get; set;}
    }
