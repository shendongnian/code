    public static class MyGenericGoodMethodsExtensions
    {
        public static T Method2(this MyGeneric<T> generic)
        {
            //does other good stuff with the generic..
        }
    }
    var myGeneric = new MyGeneric<string>();
    myGeneric.Method2()
