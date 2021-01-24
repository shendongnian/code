    const int WS_EX_LAYOUTRTL = 0x400000;
    private bool _RTL = false;
    [Description("Change to the right-to-left layout."), DefaultValue(false),
    Localizable(true), Category("Appearance"), Browsable(true)]
    public bool Mirrored
    {
        get
        {
            return _RTL;
        }
        set
        {
            if (_RTL != value)
                _RTL = value;
            base.OnRightToLeftChanged(EventArgs.Empty);
        }
    }
    protected override CreateParams CreateParams
    {
        get
        {
            CreateParams CP;
            CP = base.CreateParams;
            if (this.Mirrored)
                CP.ExStyle = CP.ExStyle | WS_EX_LAYOUTRTL;
            return CP;
        }
    }
