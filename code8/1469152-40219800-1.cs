    private string toolTipStatus;
    public string ToolTipStatus
    {
        get { return toolTipStatus; }
        set
        {
            toolTipStatus = value;
            RaisePropChanged("ToolTipStatus");
        }
    }
