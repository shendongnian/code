    class RepoItem : ICloneable
    {
        public abstract void Clone();
        protected RepoItem(RepoItem other) { Id = other.Id; }
    }
 
    class Derived1 : RepoItem
    {
        protected Derived1(Derived1 other) : base(other) 
        { 
            myField1 = other.myField1; 
        }
        public virtual object Clone() { return new Derived1(this); }
        private int myField1;
    }
    class Derived2 : Derived1
    {
        protected Derived2(Derived2 other) : base(other) 
        { 
            myField2 = other.myField2; 
        }
        public override object Clone() { return new Derived2(this); }
        private int myField2;
    }
