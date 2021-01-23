    public class CompoundCollection : ConfigurationElementCollection
    {
        public CompoundCollection()
        {
        }
        public Compound this[int index]
        {
            get { return (Compound)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }
        public void Add(Compound serviceConfig)
        {
            BaseAdd(serviceConfig);
        }
        public void Clear()
        {
            BaseClear();
        }
        protected override ConfigurationElement CreateNewElement()
        {
            return new Compound();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((Compound)element).Id;
        }
        public void Remove(Compound serviceConfig)
        {
            BaseRemove(serviceConfig.Id);
        }
        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }
        public void Remove(string name)
        {
            BaseRemove(name);
        }
    }
