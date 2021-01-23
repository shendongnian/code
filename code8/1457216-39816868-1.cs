        public interface IContainer<T> where T : UnitBase
        {
            void Add(T item);
            IEnumerable<T> Units { get; }
        }
    A specific implementation could be:
        public class Container<T>: IContainer<T> where T: UnitBase
        {
            public Container()
            {
                list = new List<T>();
            }
            private List<T> list;
            public void Add(T item) { list.Add(item); }
            public IEnumerable<T> Units => list.Select(i => i);
        }
