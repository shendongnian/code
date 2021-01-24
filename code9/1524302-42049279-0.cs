    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["mins"] = mins;
            Session["secs"] = secs; 
            tmTimer.Enabled = true;
        }
    }
    protected void tmTimer_Tick(object sender, EventArgs e)
    {
        mins = int.Parse(Session["mins"].ToString());
        secs = int.Parse(Session["secs"].ToString());
        if (secs < 0)
        {
            secs = 59;
            mins--;
        }
        if (secs < 10)
            lbSecs.Text = "0" + secs;
        else
            lbSecs.Text = "" + secs;
        if (mins < 10)
            lbMins.Text = "0" + mins;
        else
            lbMins.Text = "" + mins;
        if (secs == 0 && mins == 0)
        {
            lbMins.Text = "00";
            lbSecs.Text = "00";
            tmTimer.Enabled = false;
        }
        secs--;
        upTiempo.Update();
        Session["mins"] = mins;
        Session["secs"] = secs;
    }
