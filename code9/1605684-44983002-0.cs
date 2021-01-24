    public class SelectedDateViewModel : INotifyPropertyChanged
        {
            private readonly string FullDateFormat = "dddd, MMMM d, yyyy";
    
            private DateTime selectedDate;
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            public SelectedDateViewModel()
            {
                Debug.WriteLine("Entering SelectedDateViewModel.SelectedDateViewModel() - Constructor");
    
                SelectedDate = DateTime.Now;
    
                Debug.WriteLine("Leaving SelectedDateViewModel.SelectedDateViewModel() - Constructor");
            }
    
            public DateTime SelectedDate
            {
                get
                {
                    return selectedDate;
                }
    
                set
                {
                    if (selectedDate != value)
                    {
                        selectedDate = value;
                        OnPropertyChanged("SelectedDate");
                    }
                }
            }
    
            protected virtual void OnPropertyChanged(string propertyName)
            {
                 if (PropertyChanged != null)
                 {
                      PropertyChanged(this,
                             new PropertyChangedEventArgs(propertyName));
                 }
            }
        }
