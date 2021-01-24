    class Program
    {
        private static Type GetSomeTypePending(string typeName)
        {
            AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName("toto.dll"), AssemblyBuilderAccess.RunAndSave);
            ModuleBuilder mb = ab.DefineDynamicModule("toto.dll");
            TypeBuilder tb = mb.DefineType(typeName);
            return tb;
        }
        private static Type GetSomeTypeCreated(string typeName)
        {
            AssemblyBuilder ab = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName("toto.dll"), AssemblyBuilderAccess.RunAndSave);
            ModuleBuilder mb = ab.DefineDynamicModule("toto.dll");
            TypeBuilder tb = mb.DefineType(typeName);
            tb.CreateType(); // do not return the created type, 
            return tb;       // return the typebuilder
        }
        static void Main(string[] args)
        {
            Type foo = GetSomeTypePending("tutu");
            Type foo2 = GetSomeTypeCreated("tutu");
            if (IsPendingTypeBuilder(foo))
            {
                Console.WriteLine("foo not yet created");
            }
            else
            {
                Console.WriteLine("foo created");
            }
            if (IsPendingTypeBuilder(foo2))
            {
                Console.WriteLine("foo2 not yet created");
            }
            else
            {
                Console.WriteLine("foo2 created");
            }
        }
        private static bool IsPendingTypeBuilder(Type foo)
        {
            return (foo is TypeBuilder) && !((foo as TypeBuilder).IsCreated());
        }
    }
