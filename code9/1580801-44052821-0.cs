    class Program
    {
        public class mysecondClass
        {
             public string myName { get; set; }
            public mysecondClass()
            {
                Console.WriteLine("mysecondClass");
                myName = "Class";
            }
            public static void Display()
            {
                var mySecond = new mysecondClass();
                Console.WriteLine(mySecond.myName);
             
            }
            
            ~mysecondClass()
            {
                Console.WriteLine("second.");
            }
        }
        public class myfirstClass
        {
            public string myName { get; set; }
            public myfirstClass()
            {
                Console.WriteLine("myfirstClass");
                myName = "Class";
            }
            public static void Display()
            {
                myfirstClass d = new myfirstClass();
               
                Console.WriteLine(d.myName);
            }
            ~myfirstClass()
            {
                Console.WriteLine("first.");
            }
        }
        static void Main(string[] args)
        {
            myfirstClass.Display();
            mysecondClass.Display();
            Console.ReadLine();
        }
    }
