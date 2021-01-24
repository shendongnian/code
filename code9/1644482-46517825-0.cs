    public sealed class Singleton
    {
        private static readonly Lazy<Singleton> lazy;
    
        public static Singleton Instance 
        { 
            get 
            { 
                if (lazy == null)
                {
                    throw (...)
                }
                return lazy.Value; 
            } 
        }
    
        private Singleton(int parameter)
        {
            ...
        }
        public static Init(int parameter)
        {
            if (lazy != null)
            {
                throw (...)
            }
            lazy = new Lazy<Singleton>(() => new Singleton(parameter));
        }
    }
