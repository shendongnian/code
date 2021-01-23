    delegate void TestDelegate(myClass obj);
    void TestFunction()
    {
        TestDelegate td = (TestDelegate)this.GetType().GetMethod("myFuncName").CreateDelegate(typeof(TestDelegate));
    }
   
