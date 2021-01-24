    public override void Input0_ProcessInputRow(Input0Buffer Row)
    {
        if (Row.Column0.StartsWith("Sent:"))
        {
            this.Variables.OutputLine = Row.Column0.Substring(5);
        }
    }
