    class myParent
    {
        public int id = 3;
        protected virtual string name { get; set; } = "Parent class private string";
        public void mymethod()
        {
            Console.WriteLine("{0} & {1}", name, id);
        }
    }
    class myChild : myParent
    {
        protected override string name { get; set; } = "Child class private string";
    }
