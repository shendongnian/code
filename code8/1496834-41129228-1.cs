    public string LEL
    {
        get { return _LEL.ToString(); }
        set
        {
            int temp = Utilities.ConvertSafe.ToInt32(value);
            if  (temp < lowestSpec)
            {
                _LEL = temp; 
                NotifyPropertyChanged(this, "LEL");
            }
            else { throw new Exception("LEL not correct"); }
        }
    }
