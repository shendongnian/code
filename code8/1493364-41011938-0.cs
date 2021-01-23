    public class Child
    {
        public int? ChildID { get; set; } // the key field should be declared as Nullable<int>
        public string Name { get; set; }
    
        public virtual Parent Father { get; set; }
        public virtual Parent Mother { get; set; }
    }
    
    public class Parent
    {
        public int ParentID { get; set; }
        public string Name { get; set; }
    
        [ForeignKey("Child")]
        public int? ChildID { get; set; }
        public virtual Child Child { get; set; }
    }
