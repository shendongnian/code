    string ID {get;set;}
    
    string DisplayID 
    {
        get
        {
            return string.Format("*****{0}", ID.substring(ID.Length - 4))
        }
    }
