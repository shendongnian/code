    public class MyDerivedClass : MyBaseClass
    {
        public MyDerivedClass()
        {
            
        }
        public MyDerivedClass(MyBaseClass b)
        {
            MyProperty1 = b.MyProperty1;
        }
        public int MyProperty2 { get; set; }
    }
