    protected void Page_Load(object sender, EventArgs e)
    {
        if (panelWidth.Value != "" && panelHeight.Value != "")
        {
            Chart1.Visible = true;
            Chart1.Width = int.Parse(panelWidth.Value);
            Chart1.Height = int.Parse(panelHeight.Value);
        }
    }
