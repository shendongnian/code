    bool readOnly;
    public bool ReadOnly
    {
        get { return readOnly; }
        set
        {
            readOnly = value;
            GetTextBoxControl().ReadOnly= value;
        }
    }
    private TextBox GetTextBoxControl()
    {
        var f = this.GetType().GetField("_baseTextBox", 
                    System.Reflection.BindingFlags.NonPublic |
                    System.Reflection.BindingFlags.Instance);
        return (TextBox)f.GetValue(this);
    }
