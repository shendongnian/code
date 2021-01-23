    delegate void TestDelegate(myClass obj);
    void TestFunction()
    {
        TestDelegate tDel = () => { this.GetType().GetMethod("PrintMe").Invoke(this, null); }; tDel.Invoke();
    }
   
