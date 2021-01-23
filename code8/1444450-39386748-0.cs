    public static class GenericFactory
    {
        public static IGeneric<T> CreateGeneric<T>()
        {
            if (typeof(T) == typeof(string))
            {
                return (IGeneric<T>) new GenericString();
            }
            if (typeof(T) == typeof(int))
            {
                return (IGeneric<T>) new GenericInt();
            }
            throw new InvalidOperationException();
        }
    }
