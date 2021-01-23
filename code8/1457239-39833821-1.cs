    class UnitBase<T> : IUnit<T> where T : IContainer
    {
        protected T Container;
        public string Name { get; private set; }
        public UnitBase()
        {
            this.Name = "Default";
        }
        public void SetContainer(T container)
        {
            this.Container = container;
        }
        public bool Rename(String newName)
        {
            bool res = Container.IsNameBusy(newName);
            if (!res) this.Name = String.Copy(newName);
            return !res;
        }
    }
