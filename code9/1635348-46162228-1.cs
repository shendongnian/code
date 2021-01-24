    public bool HasErrors
    {
        get 
        {
           return !AlphaIsValid || !BetaIsValid;
        }
    }
    private bool AlphaIsValid
    {
        get {return !string.IsNullOrEmpty(Alpha);}
    }
    private bool BetaIsValid
    {
        get {return Beta == null || Beta != "";}
    }
