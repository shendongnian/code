    public event EventHandler SomethingChanged;
    private void radioButton1_CheckedChanged(object sender, EventArgs e)
    {
       if (SomethingChanged != null)
           SomethingChanged(this, EventArgs.Empty);
    }
    public bool IsSomethingEnabled => radioButton1.Checked;
