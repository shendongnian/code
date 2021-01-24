    class MyObject : IMyObject
    {
        public string MyProperty { get { return "foo"; } }
    }
    class MyDependentType : IMyDependentType
    {
        private readonly IMyObject myObject;
        public MyDependentType(IMyObject myObject)
        {
            this.myObject = myObject;
        }
        public void DoSomething()
        {
            var myProperty = this.myObject.MyProperty;
            // do something with myProperty...
        }
    }
    
