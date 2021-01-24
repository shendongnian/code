    namespace ConsoleApplication2
    {
    class myParent
    {
        public int id = 3;
        private string name = "Parent class private string";
        public void mymethod()
        {
            Console.WriteLine("{0} & {1}", name, id);
        }
    }
    class myChild : myParent
    {
        private string name = "Child class private string";
        public new void mymethod()
        {
            Console.WriteLine("{0} & {1}", name, id);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            myChild c1 = new myChild();
            c1.mymethod();
            Console.ReadLine();
        }
        //Output
        //Parent class private string & 3
    }
    }
