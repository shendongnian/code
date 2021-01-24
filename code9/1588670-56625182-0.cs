    string ID {get;set;}
    
    string DisplayID 
    {
        get
        {
            ID.MaskAllButLast(4,'*');
        }
    }
