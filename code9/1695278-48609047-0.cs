    public class MyBaseClass
        {
            public virtual int MyMethod()
            {
                return default(int);
            }
        }
    public class MyDerivedClass1:MyBaseClass
    {
        public int MyProperty1 { get; set; }
        public override int MyMethod()
        {
            return MyProperty1;
        }
    }
    public class MyDerivedClass2 : MyBaseClass
    {
        public int MyProperty2 { get; set; }
        public override int MyMethod()
        {
            return MyProperty2;
        }
    }
    public class MyConsumer
    {
        List<MyBaseClass> baselist = new List<MyBaseClass>
        {
            new MyDerivedClass1 {MyProperty1=2 },
            new MyDerivedClass2 {MyProperty2=5 }
        };
        public void TestMethod()
        {
            foreach(var item in baselist)
            {
                var x = item.MyMethod();
                /* take care of your actual logic here*/
            }
        }
