        public abstract class UnitBase
        {
            protected UnitBase()
            {
            }
            public IContainer Container { get; private set; }
            public int SomeField;
            public string Name { get; private set; }
            public void SetContainer(IContainer container)
            {
                Container = container;
            }
            public bool Rename(String newName)
            {
                 if (Container.Contains(newName))
                     return false;
                this.Name = newName; //No need to use String.Copy
                return true;
            }
        }
