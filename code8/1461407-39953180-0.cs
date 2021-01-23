    public class classA
    {
        public void show1()
        {
            Console.WriteLine("I am class A");
        }
    }
    public class classB
    {
        public void show()
        {
            new classA().show1(); 
            Console.WriteLine("I am class B");            
        }
    }
