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
    void SomeMethod()
    {
        . . .
        OriginalImgPath = "x:\\someimage.img";
        . . .
        HostUrl = "yourHostUrl";
        . . .
        if (!String.IsNullOrEmpty(OriginalImgPath) && !String.IsNullOrEmpty(HostUrl))
            FrontImagePath =  HostUrl + OriginalImgPath;
        . . .
    }
