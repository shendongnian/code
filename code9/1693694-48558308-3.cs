    void Initialize()
    {
        OtherClass otherObject = ...
        otherObject.MyPropertyChanged += this.ProcessMyPropertyChanged;
    }
    private void ProcessMyPropertyChanged(object sender, EventArgs e)
    {
         OtherClass otherObject = (OtherClass)sender;
         MyPropertyType value = otherObject.MyProperty;
         ProcessPropertyChange(value);
    }
