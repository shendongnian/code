    public class ShapeItem
    {
        public Geometry Geometry { get; set; }
        public Brush Stroke { get; set; }
    }
    public class ViewModel
    {
        public ObservableCollection<ShapeItem> ShapeItems { get; }
            = new ObservableCollection<ShapeItem>();
    }
