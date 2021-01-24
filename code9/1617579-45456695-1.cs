    private int _actualReading;
    public int ActualReading
    {
        get { return _actualReading; }
        set
        {
            if (value >= MyModel.ActualReading)
            {
                _actualReading = value;
            }
            else
            {
                UserDialogs.Instance.Alert("Meter readings should not be smaller than previous value.", "Error", "Ok");
            }
        }
    }
