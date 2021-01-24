    namespace Example.Classes
    {
        class MyClass
        {
        }
    }
    namespace Example
    {
        using Example = Example.Classes;
        class Test
        {
            static void Test1()
            {
                var c = new MyClass();  //Error
            }
        }
    }
