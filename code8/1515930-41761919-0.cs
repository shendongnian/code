    public partial class HomePage : ContentPage,  INotifyPropertyChanged
    {
    
            private string selectedSound;
            public string SelectedSound
            {
                get
                {
                    return selectedSound;
                } set
                {
                    if (selectedSound!=value)
                    {
                        selectedSound = value;
                        this.OnPropertyChanged("SelectedSound");
                    }
                }
            }
    
       .....
    
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName){
            if (PropertyChanged != null {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));}}
    
    }
