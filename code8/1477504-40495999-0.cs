    public class Animal : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Name { get; set; }
        private double _girth;
        public double girth { get { return _girth; } set { _girth = value; this.calcWeight(); } }
        private double _length;
        public double length { get { return _length; } set { _length = value; this.calcWeight(); } }
        private double _weight;
        public double weight { get { return _weight; } set { _weight = value; NotifyPropertyChanged(); } }
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    public Animal()
    {
        ...
    }
    ...
    public double calcWeight()
    {
        // formula for weight calculation goes here...
        ...
        this.weight = weight;
        return weight;
    }
    }
