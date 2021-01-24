    public string Concelho
    {
        get { return concelho; }
        set 
        { 
            conc temp;
            if(Enum.TryParse(value, true, out temp))
                cocelho = temp;
        }
    }
