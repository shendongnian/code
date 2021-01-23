    class Store : IGetProps
    {
        public Store(Bag bag)
        {
            this.bag = bag;
        }
    
        private Bag bag;        // <--- Can I designate bag to be the provide of IGetProps for Store?
    
        public int GetA() => bag.GetA();
    
        public int GetB() => bag.GetB();
    }
