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
                Boolean res = true;
                foreach (var unt in this.Container.Units)
                {
                    if (unt.Name == newName)
                    {
                        res = false;
                        break;
                    }
                }
            
                if (res) this.Name = String.Copy(newName);
                   return res;
            }
        }
