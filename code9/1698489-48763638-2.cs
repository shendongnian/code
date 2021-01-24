    public class ComponentListElement
    {
        private Component comp;
        public ComponentListElement(Component comp, Dictionary<Guid, int> positionMap)
        {
            this.comp = comp;
            this.Pos = positionMap[comp.Type.Identification];
        }
        public string Name { get { return comp.Name; } }
        public ComponentType Type { get { return comp.Type; } }
        public int Pos { get; private set; }
    }
    public class ComponentList : Collection<ComponentListElement>
    {
        private Dictionary<Guid, int> positionMap;
        public ComponentList(Dictionary<Guid, int> positionMap)
        {
            this.positionMap = positionMap;
        }
        public void Add(Component item)
        {
            base.Add(new ComponentListElement(item, positionMap));
        }
    }
