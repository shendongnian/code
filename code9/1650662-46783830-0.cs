    public void myMethodTest()
        {
            MyClass target = new MyClass();
            Isolate.Invoke.Method<MyClass>("MyMethod");
            Isolate.Verify.NonPublic.WasCalled(typeof(Dependency), "MyMethod");
        }
