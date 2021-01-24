    private void LoadSports()
    {
        // ... your code
        foreach (var r in SportsList)
            r.PropertyChanged += A_PropertyChanged;
    }
    private void A_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
         SaveSport((SportModel)sender);
    }
    private void SaveSport(SportModel sport)
    {
         // Todo
    }
    public class SportModel : ObservableObject
    {
        public string Name { get; set; }
        bool _isactive;
        public bool IsActive
        {
            get { return _isactive; }
            set
            {
                if (_isactive != value)
                {
                    _isactive = value;
                    RaisePropertyChanged("IsActive");
                }
        }
    }
    protected override void RaisePropertyChanged([CallerMemberName] string propertyName = null)
     {
         base.RaisePropertyChanged(propertyName);
     }
    }
