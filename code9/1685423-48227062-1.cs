    public class Person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        string givenNames;
        public string GivenNames
        {
            get => givenNames;
            set
            {
                if (value != givenNames)
                {
                    givenNames = value;
                    OnPropertyChanged("GivenNames");
                    OnPropertyChanged("FullName");
                }
            }
        }
    
        string familyName;
        public string FamilyName
        {
            get => familyName;
            set 
            {
                if (value != familyName)
                {
                    familyName = value;
                    OnPropertyChanged("FamilyName");
                    OnPropertyChanged("FullName");
                }
            }
        }
    
        public string FullName => $"{GivenNames} {FamilyName}";
    
        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
