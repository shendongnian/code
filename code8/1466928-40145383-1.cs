    public class SomeClass
    {
        public int x;
    }
    public class MyGlobals
    {
        public static SomeClass mySharedVariable = new SomeClass();
        public SomeClass myGlobalVariable = null;
    }
    // Usage:
    class Program
    {
        static void Main(string[] args)
        {
            MyGlobals.mySharedVariable.x = 10; // Shared among all instances
            MyGlobals myGlobal = new MyGlobals(); // New instance of MyGlobals
            myGlobal.myGlobalVariable = new SomeClass(); // New instance of SomeClass
            myGlobal.myGlobalVariable.x = 10; // One instance of MyGlobals including one instance of SomeClass
        }
    }
