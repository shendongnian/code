    static public class DynamicTypeTest
    {
        public class Generic<T> { }
        static public void Test()
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            Type dynamicType = createDynamicType();
            Type genericType = typeof(Generic<>);
            // Generic<DynamicType>
            Type genericDynamicType = genericType.MakeGenericType(new Type[]{dynamicType});
            Debug.Assert(TypeFromName(genericDynamicType.FullName) == genericDynamicType);              // pass
            
            AppDomain.CurrentDomain.AssemblyResolve -= CurrentDomain_AssemblyResolve;
        }
        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                AssemblyName assemblyName = assembly.GetName();
                if (args.Name == assemblyName.FullName)
                {
                    return assembly;
                }
            }
            return null;
        }
        // This is the essence of what I want to do
        static private Type TypeFromName(string name)
        {
            try
            {
                return typeof(Generic<>).Assembly.GetType(name, true);
            }
            catch (Exception)
            {
                return null;
            }
        }
        static private Type createDynamicType()
        {
            AssemblyName assemblyName = new AssemblyName("DynamicAssembly");
            AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("DynamicModule");
            TypeAttributes typeAttributes = TypeAttributes.Public | TypeAttributes.Class | TypeAttributes.AutoClass | TypeAttributes.AnsiClass;
            TypeBuilder typeBuilder = moduleBuilder.DefineType("DynamicType", typeAttributes, typeof(System.Object));
            return typeBuilder.CreateType();
        }
