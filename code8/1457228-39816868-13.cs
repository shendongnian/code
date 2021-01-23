        public abstract class UnitBase
        {
            protected UnitBase(IContainer<UnitBase> container, int someField, string name)
            {
                Container = container;
                SomeField = someField;
                Name = name;
            }
            IContainer<UnitBase> Container { get; }
            public int SomeField;
            public string Name { get; private set; }
            public bool Rename(String newName)
            {
                if (Container.Contains(newName))
                    return false;
                   
                this.Name = newName; //No need to use String.Copy
                return true;  
            }
        }
