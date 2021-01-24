    public class Test
    {
        public void TestIt(Test t)
        {
            t.Value = 42;
        }
    
        public int Value
        {
            get;
            private set;
        }
    }
    ...
    var t1 = new Test();
    var t2 = new Test();
    t1.TestIt(t2); // will "happily" change t2.Value
