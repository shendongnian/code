    /// <summary>
    /// Single ton class
    /// </summary>
    public sealed class Singleton
    {
        private static Lazy<Singleton> lazy = null;
        /// <summary>
        /// You can use this param even  you can pass to your base class
        /// </summary>
        /// <param name="parameter"></param>
        private Singleton(int parameter)
        {
        }
        /// <summary>
        /// Creaeting single object
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static Singleton CreateSingletonObj(int parameter)
        {
            if (lazy == null)
            {
                lazy = new Lazy<Singleton>(() => new Singleton(parameter));
            }
            return lazy.Value;
        }
    }
