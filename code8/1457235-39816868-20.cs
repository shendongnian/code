        public interface IContainer
        {
            Q Add<Q>() where Q : UnitBase, new();
            IEnumerable<UnitBase> Units { get; }
            bool Contains(string name);
        }
    A specific implementation of `IContainer` could be the following:
        public class Container : IContainer
        {
            public Container()
            {
                list = new List<UnitBase>();
            }
            private List<UnitBase> list;
            public Q Add<Q>() where Q: UnitBase, new()
            {
                var newItem = Activator.CreateInstance<Q>();
                newItem.SetContainer(this);
                list.Add(newItem);
                return newItem;
            }
            public IEnumerable<UnitBase> Units => list.Select(i => i);
            public bool Contains(string name) =>
                Units.Any(unit => unit.Name == name);
        }
