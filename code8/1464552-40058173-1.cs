    protected void Page_Load(object sender, EventArgs e)
        {
            Control[] allControls = FlattenHierachy(Page);
            foreach (Control control in allControls)
            {
                Label lbl = control as Label;
                if (lbl != null && lbl.ID == "FromName0")
                {
                    lbl.ID = Session["DeliverAddress" + i].ToString();//Do your like stuff
                }
            }
        }
