    private string _tb1;
    public string tb1
    {
        get { return _tb1; }
        private set
        {
            tb1 = value;
            message_click();
        }
    }
