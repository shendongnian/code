    protected void Page_Init(object sender, EventArgs e)
    {
        LinkButton lbLink = new LinkButton();
        lbLink.Text = "Click Here!";
        lbLink.Click += new EventHandler(getMethod);
        phTest.Controls.Add(lbLink);
    }
    protected void getMethod(object sender, EventArgs e)
    {
        lblMessage.Text = "Hi!";
    }
