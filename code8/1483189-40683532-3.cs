    ToolTip toolTip1;
    public SampleForm()
    {
        toolTip1 = new ToolTip();
        this.Text = "Sample Form";
        this.NonClientMouseHover += SampleForm_NonClientMouseHover;
        this.FormClosed += SampleForm_FormClosed;
    }
    void SampleForm_NonClientMouseHover(object sender, EventArgs e)
    {
        var p = PointToClient(Parent.PointToScreen(this.Location));
        p.Offset(0,-24);
        toolTip1.Show(this.Text, this, p, 2000);
    }
    void SampleForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        toolTip1.Dispose();
    }
