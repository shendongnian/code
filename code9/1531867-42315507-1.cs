    public string myLegacyDataString;
    public string MyDataString{
        get {return myLegacyDataString.Replace("< br >",System.Environment.NewLine);}
        set {myLegacyDataString = value.Replace(System.Environment.NewLine, "< br >");}
    }
