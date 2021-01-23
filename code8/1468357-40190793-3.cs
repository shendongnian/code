    public class ShapeData
    {
        public string Type { get; set; }
        public Geometry Geometry { get; set; }
        public Brush Fill { get; set; }
        public Brush Stroke { get; set; }
        public double StrokeThickness { get; set; }
    }
    public class ViewModel
    {
        public ObservableCollection<ShapeData> Shapes { get; }
            = new ObservableCollection<ShapeData>();
    }
