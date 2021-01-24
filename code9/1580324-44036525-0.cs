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
             if (new Random().NextDouble() < .000001) UsedByConstructor();
         }
         public EarlyDependency MethodWithReturnType();
         public static EarlyDependency StaticMethodWithReturnType();
         public void MethodWithParameter(EarlyDependency parameter);
         public void UseIt()
         {
             LateDependency localInNonSpecialMethod;
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
