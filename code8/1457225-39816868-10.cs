        public class BUnit: UnitBase
        {
            public int SpecificBProperty { get; private set; }
            public BUnit(IContainer<UnitBase> container, int someField, string name, int specificBProperty)
                : base(container, someField, name)
            {
                SpecificBProperty = specificBProperty;
            }
        }
