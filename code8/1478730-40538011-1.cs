    public  ImageSource ButtonImage
    {
        get { return b; }
        set
        {
            b = value;
            PropertyChanged("ButtonImage");
        }
    }
