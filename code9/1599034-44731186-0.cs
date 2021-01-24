    namespace ConsoleApplication1
    {
        class Class1
        {
            internal string thing;
            public Class1()
            {
                thing = "original data";
            }
        }
    }
    namespace ConsoleApplication2
    {
        class Class2
        {
            public ConsoleApplication1.Class1 class1= new ConsoleApplication1.Class1();
            public Class2()
            {
                class1.thing = "other namespace modification";
            }
        }
    }
