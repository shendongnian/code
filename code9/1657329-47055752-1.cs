    string _frontImgPath = string.Empty;
    
    public string FrontImagePath
    {
        get{
            return _frontImgPath;
        }
        set{
            _frontImgPath = value;
        }
    }
    private void SomeMethod()
    {
        . . .
        if (!String.IsNullOrEmpty(OriginalImgPath) && !String.IsNullOrEmpty(HostUrl))
            FrontImagePath =  HostUrl + OriginalImgPath;
        . . .
    }
