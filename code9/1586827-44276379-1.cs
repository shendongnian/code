    public class MyModel:INotifyPropertyChanged
    {
        string _name;
        string _description;
        public event PropertyChangedEventHandler PropertyChanged;
        public string Name 
        { 
            get => _name; 
            set
            {
                _name = value;
                OnPropertyChanged(); 
            } 
        }
        public string Description 
        { 
            get => _description;
            set
            {
                _Description = value; 
                OnPropertyChanged(); 
            }
        }
    
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
