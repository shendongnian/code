    public class MyFirstClass
    {
        //true or false parameters indicates whether to throw 
        // a compile error (true) or warning (false)
        [Obsolete("Please use the method PrintSelf() instead of ToString()", false)]
        public overrides string ToString()
        {
            //Whatever code you want here
            return "";
        }
    }
    public class MySecondClass
    {
        public void Test()
        {
            mfc = new MyFirstClass();
            mfc.ToString(); //Here you will get a compiler warning
        }
    }
