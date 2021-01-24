    public class Parent
    {
        public int Id {get;set;}
        public string name{get;set;}
        // Every parent has zero or more Children
        public virtual ICollection<Child> Children {get;set;}
    }
    public class Child
    {
        public int id {get;set;}
        public bool Imported{get;set;}
        public DateTime? TimeSpan {get;set;}
        // every Child belongs to exactly one Parent using foreign key
        public int ParentId {get; set;}
        public Parent Parent {get; set;}
    }
