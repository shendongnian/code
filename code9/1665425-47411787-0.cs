    public class Condition : INotifyPropertyChanged
    { 
        public void SetPropertyChanged(string propertyName)
        {
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public int Id { get; set; }
        public string Description { get; set; }
        private bool popUpOpen;
        public bool PopUpOpen
        {
            get { return popUpOpen; }
            set
            {
                popUpOpen = value;
                OnPropertyChanged("PopUpOpen");
            }
         }
        public string PopupContent { get; set; }
        …
    }
