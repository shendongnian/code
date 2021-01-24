    class Program
    {
        static void Main(string[] args)
        {
            new Foo<int>().Bar<int>(1,1);
        }
        class Foo<T>
        {
            public void Bar<S>(T a, S b)
            {
                var argType1 = typeof(Foo<>).GetMethod("Bar").GetParameters()[0].ParameterType;
                var argType2 = typeof(Foo<>).GetMethod("Bar").GetParameters()[1].ParameterType;
    
                var argType1_res = Ext.IsClassGeneric(argType1);//true
                var argType2_res = Ext.IsClassGeneric(argType2);//false
            }
    
        }
    }
