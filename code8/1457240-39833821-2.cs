    class ContainerBase<U, C> : IContainer //U - Unit Class.  C-Container Class
        where U : IUnit<C>, new()
        where C : ContainerBase<U, C>
    {
        protected List<U> Units;
        public U this[int index] { get { return Units[index]; } }
        public ContainerBase()//ctor
        {
            this.Units = new List<U>();
        }
        public void Add()
        {
            this.Units.Add(new U());
            this.Units.Last().SetContainer(((C)this));//may be a bit strange but actualy this will have the same type as <C>
        }
        public bool IsNameBusy(String newName)
        {
            bool res = false;
            foreach (var unt in this.Units)
            {
                if (unt.Name == newName)
                {
                    res = true;
                    break;
                }
            }
            return res;
        }
        public int Count { get { return this.Units.Count; } }
    }
