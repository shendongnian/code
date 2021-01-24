    using System;
    public class Hello
    {
         public static void Main()
        {
            var message = "hiiii inside => Works"   ;
            Console.WriteLine(message);
            HW();
        }
        public static void HW(){
            Console.WriteLine("Hello, World!");
            // the ReadLine will not work because it is only one way solution : ouptut only
            // var a = Console.ReadLine();
            // Console.WriteLine("key pressed: " + a + "Doesn't work");
        }
    }
    Hello.Main();
    //can be used like this as well
    var message= "Hey helloooo outside WORKS";
    Console.WriteLine(message);
