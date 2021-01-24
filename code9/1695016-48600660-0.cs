    public Color MyColor
    {
        get {
           return Properties.Settings.Default.myColor;
        }
    
        set {
            Properties.Settings.Default.myColor = value; RaisePropertyChanged();
        }
    }
    public void Persist()
    {
        Properties.Settings.Default.Save();
        // Raise whatever needed !
    }
