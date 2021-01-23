    namespace Test
    {
        using System;
        public class MyObject
        {
            public string Value { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                MyObject obj = new MyObject() { Value = "original" };
                Console.WriteLine(obj.Value);
                Change2(obj);
                Console.WriteLine(obj.Value);
                Change3(ref obj);
                Console.WriteLine(obj.Value);
                Console.ReadKey();
            }
            private static void Change(MyObject obj)
            {
                obj.Value = "aaa";
            }
            private static void Change2(MyObject obj)
            {
                obj = new MyObject() { Value="You can't see this outside the method" };
                Console.WriteLine("Inside Change 2 "+obj.Value);
            }
            private static void Change3(ref MyObject obj)
            {
                obj = new MyObject() { Value = "You CAN see this outside the method" };
                Console.WriteLine("Inside Change 3 " + obj.Value);
            }
        }
    }
