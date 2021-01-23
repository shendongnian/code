    private bool _IsAllowAdd = true;
    [Browsable(true)]
    [NotifyParentProperty(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Description("Gets and sets the visibility of the Add")]
    public bool AllowAdd
    {
        get
        {
            return _IsAllowAdd;
        }
        set
        {
            _IsAllowAdd = value;
        }
    }
