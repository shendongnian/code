    class ClassA : EarlyDependency, IComparable<EarlyDependency>
    {
         EarlyDependency field;
         property EarlyDependency PropertyA { get; set; }
         int initialized = new EarlyDependency().Calculate();
         int initializedB = LateDependency.LiteralConstant;
         static ClassA
         {
             EarlyDependency localInStaticConstructor;
         }
         public ClassA()
         {
             EarlyDependency localInInstanceConstructor;
             if (new Random().NextDouble() < .000001) {
                 try {
                     // you can't catch inside the function that fails to compile
                     // because code inside that function can't ever run
                     UsedByConstructor();
                 }
                 catch (TypeLoadException)
                 {
                 }
             }
         }
         public EarlyDependency MethodWithReturnType();
         public static EarlyDependency StaticMethodWithReturnType();
         public void MethodWithParameter(EarlyDependency parameter);
         public void UseIt()
         {
             LateDependency localInNonSpecialMethod;
         }
         public void Safe()
         {
             try {
                 // you can't catch inside the function that fails to compile
                 // because code inside that function can't ever run
                 UseIt();
             }
             catch (TypeLoadException)
             {
             }
         }
         public static void UseItSomeMore()
         {
             LateDependency localInStaticMethod;
         }
         private void UsedByConstructor()
         {
             LateDependency localInMethodNamedInConstructor;
         }
    }
