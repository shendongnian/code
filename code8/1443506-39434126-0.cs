    public abstract class EnumHelper<T> where T : struct
    {
        static T[] _valuesCache = (T[])Enum.GetValues(typeof(T));
   
        public virtual string GetEnumName()
        {
            return GetType().Name;
        }
        public static T[] GetValuesS()
        {
            return _valuesCache;
        }
        public T[] GetValues()
        {
            return _valuesCache;
        }      
        virtual public string EnumToString(T value)
        {
            return value.ToString();
        }                
    }
