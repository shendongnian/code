    protected override void OnPreRender(System.EventArgs e)
    {
        base.OnPreRender(e);
        LiteralControl lc = new LiteralControl(this.Text);
        lc.Attributes.Add("onclick",this.OnClientClick);
        Controls.Add(lc);
        base.Text = UniqueID;
    }
