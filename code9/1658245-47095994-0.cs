    // naive implementation of singleton, but demostrates the basics
    public class Singleton
    {
        private static Singleton instance;
        static Singleton()
        {
             this.instance = new Singleton();
        }
    
        public static Singleton Instance{ get { return instance; } }
        private Singleton() {}
        public void DoSomething() { ... }
    }
