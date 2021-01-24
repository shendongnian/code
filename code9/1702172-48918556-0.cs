    public class BaseFactory
    {
        private static object _monitor = new object();
        protected T CreateInstance<T>(string assemblyFile, string fullyQualifiedClassName, params object[] arguments)
        {
            lock(_monitor)
            {
                Assembly assembly = Assembly.LoadFrom(assemblyFile);
                Type classType = assembly.GetType(fullyQualifiedClassName);
                T instance = (T)Activator.CreateInstance(classType, arguments);
                return instance;
            }
        }
    }
