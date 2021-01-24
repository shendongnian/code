    public class ViewModel : ObservableBase // Made this up. It should implement INotifyPropertyChanged
    {
        private bool _isDROFocused { get; set; }
        
        public bool IsDigitalReadOutFocused
        {  
            get { return this._isDROFocused; }
            set
            {
                this._isDROFocused = value;
                OnPropertyChanged("IsDigitalReadOutFocused");
            }
        }
    
        // On your Serial Data Received event handler
    
        //if(!IsDigitalReadOutFocused)
        //{
        //  DigitalReadOut = somevalue; // Set the textbox value
        //}
    }
