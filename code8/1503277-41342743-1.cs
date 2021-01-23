    public class MyObject
    {
        public static Type GetMyObjectClassType()
        {
            return typeof(MyObject);
        }
        public static Type GetMyObjectInstanceType(MyObject someObject)
        {
            return someObject.GetType();
        }
        public static Type GetAnyClassType<GenericClass>()
        {
            return typeof(GenericClass);
        }
        public static Type GetAnyObjectInstanceType(object someObject)
        {
            return someObject.GetType();
        }
        public void Demo()
        {
            var someObject = new MyObject();
            Console.WriteLine(GetMyObjectClassType()); // will write the type of the class MyObject
            Console.WriteLine(GetMyObjectInstanceType(someObject)); // will write the type of your instance of MyObject called someObject
            Console.WriteLine(GetAnyClassType<MyObject>()); // will write the type of any given class, here MyObject
            Console.WriteLine(GetAnyClassType<System.Windows.Application>()); //  will write the type of any given class, here System.Windows.Application
            Console.WriteLine(GetAnyObjectInstanceType("test")); // will write the type of any given instance, here some string called "test"
            Console.WriteLine(GetAnyObjectInstanceType(someObject)); // will write the type of any given instance, here your instance of MyObject called someObject
        }
    }
