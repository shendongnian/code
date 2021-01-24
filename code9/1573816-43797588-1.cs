    private string _labelText="<default string to appear>";
    public string LabelText
    {
        get { return _labelText; }
        set
        {
            _labelText= value;
            OnPropertyChanged ();
        }
    }
