    public class SomeClass
    {
        public int x;
    }
    public class MyGlobals
    {
        public static SomeClass mySharedVariable = new SomeClass();
        public SomeClass myGlobalVariable = null;
    }
    // usage:
    class Program
    {
        static void Main(string[] args)
        {
            MyGlobals.mySharedVariable.x = 10; // shared among all instances
            MyGlobals myGlobal = new MyGlobals(); // new instance of MyGlobals
            myGlobal.myGlobalVariable = new SomeClass(); // new instance of SomeClass
            myGlobal.myGlobalVariable.x = 10; // One instance of MyGlobals including one instance of SomeClass
        }
    }
