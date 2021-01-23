    class Parent
    {
        public static Parent ParseFromA(string filename)
        {
            Parent parent = new Parent();
            parent.Parse(filename);
            return parent;
        }
    
        protected virtual void Parse(string fileName)
        {
            ...
        }
    }
    
    class Child : Parent
    {
        public new static Child ParseFromA(string filename)
        {
            Child child = new Child();
            child.Parse(filename);
            return parent;
        }
    
        protected override void Parse(string fileName)
        {
            base.Parse(fileName);
            SomeAdditionalFunction();
        }
    }
