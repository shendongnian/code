    using Microsoft.VisualStudio.TestTools.UnitTesting;
    class Class1
    {
        public Class1()
        {
            MyClass myClass = new MyClass();
            PrivateObject myClassPrivateObject = new PrivateObject(myClass, new PrivateType(typeof(MyClass)));
            myClassPrivateObject.Invoke("MyMethod");
        }
    }
