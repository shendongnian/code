    class Parent
    {
        public Parent() { }
        public Parent(string fileName) 
        {
             Parse(fileName);
        }
        private void Parse(string fileName)
        {
            // Do your parsing stuff here.
        }
    }
    class Child : Parent
    {
        public Child() { }
        public Child(string fileName) : base(fileName)
        {
             // Parsing is done already done within the constructor of Parent, which is called by base(fileName)
             // All you need to do here is initialize the rest of your child object.
        }
    }
