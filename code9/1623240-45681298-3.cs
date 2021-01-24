    public string Title
    {
        set 
        {  
            _Title = value;
            cmb_Title.Items.Add(_Title);
        }
        get 
        { 
            return _Title; 
        }
    }
