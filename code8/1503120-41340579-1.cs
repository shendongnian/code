    public class TestVM : INotifyPropertyChanged
        {
            Thickness myThickness = new Thickness(20,10,20,0);
    
            public Thickness MyThickness
            {
                get { return myThickness; }
                set { myThickness = value; OnPropertyChanged(); }
            }
    
    
    
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
