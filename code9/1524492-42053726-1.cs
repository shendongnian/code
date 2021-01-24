    class myParent
    {
        public int id = 3;
        private string name = "Parent class private string";
        public virtual void mymethod()
        {
            Console.WriteLine("{0} & {1}", name, id);
        }
    }
    class myChild : myParent
    {
        private string name = "Child class private string";
        public override void mymethod()
        {
            Console.WriteLine("{0} & {1}", name, id);
        }
    }
