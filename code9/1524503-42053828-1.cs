    class myParent
    {
        public int id = 3;
        protected string name = "Parent class private string";
        public void mymethod()
        {
            Console.WriteLine("{0} & {1}", name, id);
        }
    }
    class myChild : myParent
    {
        public myChild()
        {
            name = "Child class private string";
        }
    }
