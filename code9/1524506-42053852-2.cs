    class myParent
    {
        public int id = 3;
        private string name;
        public myParent() : this("Parent class private string")
        {
        }
        protected myParent(string name)
        {
            this.name = name;
        }
        public void mymethod()
        {
            Console.WriteLine("{0} & {1}", name, id);
        }
    }
    class myChild : myParent
    {
        public myChild() : base("Child class private string")
        {
        }
    }
