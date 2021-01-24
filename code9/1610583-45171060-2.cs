    public override void PostExecute()
    {
        base.PostExecute();
        this.Variables.OutputLine = LineValue;
    }
    // Add this variable that will hold the desired line value.
    string LineValue = "";
    public override void Input0_ProcessInputRow(Input0Buffer Row)
    {
        if (Row.Column0.StartsWith("Sent:"))
        {
            LineValue = Row.Column0.Substring(5);
        }
    }
