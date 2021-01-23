    private void button1_Click(object sender, EventArgs e)
    {
        Session["PrevClickTime"] = Session["PrevClickTime"] ?? DateTime.Now.AddDays(-1);
        if (((DateTime)Session["PrevClickTime"]).Subtract(DateTime.Now).Milliseconds >= 2000)
        {
            label1.Text = "Speed reached!";
        }
        else
        {
            // do y
        }
        Session["PrevClickTime"] = DateTime.Now
    }
