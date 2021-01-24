    class Parent
    {
         public int Id {get; set;}
         // a Parent has zero or more Children:
         public virtual ICollection<Child> Children {get; set;}
         ...
    }
    public class Child
    {
        public int Id {get; set;}
        // a Child belongs to exactly one Parent, via foreign key ParentId:
        public int ParentId {get; set;}
        public virtual Parent Parent {get; set;}
    }
