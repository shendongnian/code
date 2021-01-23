    public partial class Parent {
        public virtual int ParentId 
        public virtual string Name
    }
    public class Child {
        public virtual int ChildId 
        public virtual string Name
        public virtual Parent Parent
    }
