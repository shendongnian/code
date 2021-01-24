    public int TeamPoints
    {
        get { return Team1.TeamPoints; }  
        set { Team1.TeamPoints = value; OnPropertyChanged("TeamPoints"); }
    }
