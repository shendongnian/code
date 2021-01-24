    public sealed class Manager
    {
        private static readonly Lazy<Singleton> lazyOne = new Lazy<Manager>(() => new Manager());
        private static readonly Lazy<Singleton> lazyTwo = new Lazy<Manager>(() => new Manager());
        
        public static Manager GetOne() { return lazyOne.Value; }
        public static Manager GetTwo() { return lazyTwo.Value; }
    }
