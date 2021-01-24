    public class ModelLine : INotifyPropertyChanged
    {
        int _x1;
        public int X1 { get { return _x1; } set { _x1 = value; RaisePropertyChanged("X1"); } }
        int _x2;
        public int X2 { get { return _x2; } set { _x2 = value; RaisePropertyChanged("X2"); } }
        int _y1;
        public int Y1 { get { return _y1; } set { _y1 = value; RaisePropertyChanged("Y1"); } }
        int _y2;
        public int Y2 { get { return _y2; } set { _y2 = value; RaisePropertyChanged("Y2"); } }
        double _opacity;
        public double Opacity { get { return _opacity; } set { _opacity = value; RaisePropertyChanged("Opacity"); } }
        Brush _brush;
        public Brush Brush { get { return _brush; } set { _brush = value; RaisePropertyChanged("Brush"); } }
        double _thickness;
        public double Thickness { get { return _thickness; } set { _thickness = value; RaisePropertyChanged("Thickness"); } }
        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged(string propname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }
    }
