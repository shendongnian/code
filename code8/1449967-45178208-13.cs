    // assuming namespace Contosco
    public class GenericTestMethod : MarshalByRefObject, ITestMethod, IXunitSerializable
    {
        public IMethodInfo Method { get; set; }
        public ITestClass TestClass { get; set; }
        public ITypeInfo GenericArgument { get; set; }
        /// <summary />
        [Obsolete("Called by the de-serializer; should only be called by deriving classes for de-serialization purposes")]
        public GenericTestMethod()
        {
        }
        public GenericTestMethod(ITestClass @class, IMethodInfo method, ITypeInfo genericArgument)
        {
            this.Method = method;
            this.TestClass = @class;
            this.GenericArgument = genericArgument;
        }
        public void Serialize(IXunitSerializationInfo info)
        {
            info.AddValue("MethodName", (object) this.Method.Name, (Type) null);
            info.AddValue("TestClass", (object) this.TestClass, (Type) null);
            info.AddValue("GenericArgumentAssemblyName", GenericArgument.Assembly.Name);
            info.AddValue("GenericArgumentTypeName", GenericArgument.Name);
        }
        public static Type GetType(string assemblyName, string typeName)
        {
    #if XUNIT_FRAMEWORK    // This behavior is only for v2, and only done on the remote app domain side
            if (assemblyName.EndsWith(ExecutionHelper.SubstitutionToken, StringComparison.OrdinalIgnoreCase))
                assemblyName = assemblyName.Substring(0, assemblyName.Length - ExecutionHelper.SubstitutionToken.Length + 1) + ExecutionHelper.PlatformSuffix;
    #endif
    #if NET35 || NET452
            // Support both long name ("assembly, version=x.x.x.x, etc.") and short name ("assembly")
            var assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.FullName == assemblyName || a.GetName().Name == assemblyName);
            if (assembly == null)
            {
                try
                {
                    assembly = Assembly.Load(assemblyName);
                }
                catch { }
            }
    #else
            System.Reflection.Assembly assembly = null;
            try
            {
                // Make sure we only use the short form
                var an = new AssemblyName(assemblyName);
                assembly = System.Reflection.Assembly.Load(new AssemblyName { Name = an.Name, Version = an.Version });
            }
            catch { }
    #endif
            if (assembly == null)
                return null;
            return assembly.GetType(typeName);
        }
        public void Deserialize(IXunitSerializationInfo info)
        {
            this.TestClass = info.GetValue<ITestClass>("TestClass");
            string assemblyName = info.GetValue<string>("GenericArgumentAssemblyName");
            string typeName = info.GetValue<string>("GenericArgumentTypeName");
            this.GenericArgument = Reflector.Wrap(GetType(assemblyName, typeName));
            this.Method = this.TestClass.Class.GetMethod(info.GetValue<string>("MethodName"), true).MakeGenericMethod(GenericArgument);
        }
    }
