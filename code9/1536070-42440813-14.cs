    public class Container : IContainer {
        public Container() {
            Components = new List<IComponent>();
        }
        public IList<IComponent> Components { get; }
    }
