    public class Component
    {
        public Component() { }
        public ObservableCollection<Component> ComponentsToDraw { set; get; } = new ObservableCollection<Component>();
        public double X { set; get; }
        public double Y {
            set;
            get;
        }
        public double Z { set; get; }
        public double Width {
            set;
            get;
        }
        public double Height { set; get; }
        public Brush Color { set; get; }
        public string Name { set; get; }
    }
