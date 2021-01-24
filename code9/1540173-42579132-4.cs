    public int TeamPoints
    {
        get { return TeamPoints; } //should be Team1.TeamPoints
        set { TeamPoints = value; OnPropertyChanged("TeamPoints"); } //should be Team1.TeamPoints
    }
