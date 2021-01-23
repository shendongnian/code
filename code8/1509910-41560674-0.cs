    interface IGetProps
    {
        int GetA();
        int GetB();
    }
    
    struct Bag : IGetProps
    {
        public int GetA() { return 0; }
        public int GetB() { return 1; }
    }
    
    class Store : IGetProps
    {
        private Bag bag;        // <--- Can I designate bag to be the provide of IGetProps for Store?
    
        public int GetA() => bag.GetA(); // <--- c# 6.0 syntax for wrapping a method
    
        public int GetB() => bag.GetB();
    }
