    public class Team : INotifyPropertyChanged
    {
        public string KnownName { get; set; }     //player known name
        public string Number { get; set; }    
        public bool isActive;
        public bool IsActive
        {
            get { return IsActive; }
            set
            {
                if (value != isActive)
                {
                    isActive = value;
                    if(isActive)
                    {
                        OnPropertyChanged("IsActive", true);
                    }
                    else
                    {
                        OnPropertyChanged("IsActive", false);
                    }
                    
                }
            }
        }
    }
    protected void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null)
            handler(this, e);
    }
    protected void OnPropertyChanged(string propertyName, bool state)
    {
        OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        if(state)
        {
            WindowType1.HomeTeam.Add(this);
        }
        else
        {
            WindowType1.HomeTeam.Remove(WindowType1.HomeTeam.Where(i => i.Number == this.Number).Single());
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;
