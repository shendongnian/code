    public class MyItem : INotifyPropertyChanged
    {
        public void SetPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    
        private bool isItemChecked = false;
        public bool IsItemChecked
        {
            get { return isItemChecked; }
            set
            {
                isItemChecked = value;
                SetPropertyChanged("IsItemChecked");
            }
        }
    
        private string name ;
        public string Name
        {
            get { return Name; }
            set
            {
                name = value;
                SetPropertyChanged("Name");
            }
        }
    }
