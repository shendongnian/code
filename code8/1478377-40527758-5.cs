    protected void OnClick(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lbl.Text = this.tb.Text;
        }
    }
