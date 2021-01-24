    public class Number : INotifyPropertyChanged
    {
        public int FirstNumber { get; set; }
        public int LastNumber { get; set; }
        public int PlusNumber { get; set; }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        public void NotifyPropertyChanged(string propertyName)
        { 
            //... 
        }
    }
