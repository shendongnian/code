    public class GenericType<T> where T : new()
    {
        public T MethodName()
        {
            return new T();
        }
    }
    public class TOutput
    {
    }
