    public abstract class Sentinel<T,U> where T: new() where U: new() 
    {
        public T CreateModel(IDictionary<String, Object> parametersDictionary)
        {
            T toReturn ;
            if (ValidateDictionary(parametersDictionary) != true)
                return default(T);
            else
            {
                U parameters = ParseDictionaryToParameters(parametersDictionary);
                toReturn = (T)Activator.CreateInstance(typeof(T), new object[] {parameters});
            }
            //If we got this far then everything should be fine.
            return toReturn;
        }
        public abstract U ParseDictionaryToParameters(IDictionary<String, Object> parametersDictionary);
        public abstract Boolean ValidateDictionary(IDictionary<String, Object> parametersDictionary);
    }
