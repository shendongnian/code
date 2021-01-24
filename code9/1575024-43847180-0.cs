    public class MyReflector
    {
        string myNamespace;
        Assembly myAssembly;
        public MyReflector(string assemblyName, string namespaceName)
        {
            myNamespace = namespaceName;
            myAssembly = null;
            var alist=Assembly.GetExecutingAssembly().GetReferencedAssemblies();
            foreach (AssemblyName aN in alist)
            {
                if (aN.FullName.StartsWith(assemblyName))
                {
                    myAssembly = Assembly.Load(aN);
                    break;
                }
            }
        }
        public Type GetType(string typeName)
        {
            Type type = null;
            string[] names = typeName.Split('.');
            if (names.Length > 0)
                type = myAssembly.GetType(myNamespace + "." + names[0]);
            for (int i = 1; i < names.Length; ++i)
            {
                type = type.GetNestedType(names[i], BindingFlags.NonPublic);
            }
            return type;
        }
        public object Call(Type type, object obj, string func, object[] parameters)
        {
            MethodInfo methInfo = type.GetMethod(func, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            return methInfo.Invoke(obj, parameters);
        }
        public object GetField(Type type, object obj, string field)
        {
            FieldInfo fieldInfo = type.GetField(field, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            return fieldInfo.GetValue(obj);
        }
    }
