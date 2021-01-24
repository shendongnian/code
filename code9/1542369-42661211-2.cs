    public class MyClass
    {
        public MyClass(ITest1 interface1, ITest2 interface2, ITest3 interface3)
        {
            this.interface1 = interface1;
            this.interface2 = interface2;
            this.interface3 = interface3;
        }
    
        public void TestMethod()
        {
            var lines = interface1.GetData();
            var file = interface2.Parse(lines);
            interface3.Copy(file);
        }
    
        private readonly ITest1 interface1;
        private readonly ITest2 interface2;
        private readonly ITest3 interface3;
    }
