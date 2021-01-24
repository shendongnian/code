    public static class ReflectionHelper
    {
        public static List<T> GetAllNonabstractClassesOf<T>()
        {
            Object[] args = new Object[0];
            return GetAllNonabstractClassesOf<T>(args);
        }
        public static List<T> GetAllNonabstractClassesOf<T>(Object[] args)
        {
            List<T> retVal = new List<T>();
            IEnumerable<object> instances = from t in Assembly.GetExecutingAssembly().GetTypes()
                                            where t.IsSubclassOf(typeof(T)) && !t.IsAbstract
                                            select Activator.CreateInstance(t, args) as object;
            foreach (T instance in instances)
            {
                retVal.Add(instance);
            }
            return retVal;
        }
    }
