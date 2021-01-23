    private Dictionary<string, string> playersMuteStatus = new... ;
    public IReadOnlyDictionary<string, string> MuteStatuses
    {
        get
        {
            return playersMuteStatus as IReadOnlyDictionary<string, string>;
        }
    }
