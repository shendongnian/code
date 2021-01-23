    private void Button1_Click(object sender, EventArgs e)
    {
        //myControl[0].label1.Text = "Other Title";
        MyUserControl ctrl = null;
        foreach (var c in this.Controls)
        {
            if (c.GetType().Name == "MyUserControl")
            {
                var myctrl = (MyUserControl)c;
                if (myctrl.Text == "Title")
                {
                    ctrl = myctrl;
                    break;
                }
            }
        }
        if (ctrl != null)
        {
            ctrl.Text = "Other Title";
        }
    }
