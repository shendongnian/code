    public class ColorInfo
    {
        private ObservableCollection<string> _color;
        public ObservableCollection<string> Colors
        {
            get { return _color; }
            set { _color = value; }
        }
        public ColorInfo()
        {
            Colors = new ObservableCollection<string>();
            Colors.Add("Red");
            Colors.Add("White");
            Colors.Add("Orange");
            Colors.Add("Blue");
            Colors.Add("Purple");
            Colors.Add("Pink");
            Colors.Add("SkyBlue");
            Colors.Add("Yellow");
        }
    }
