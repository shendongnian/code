    private void check_Click(object sender, EventArgs e)
    {
        textbox.Text = "";
       
        foreach(var ctl in Controls)
        {
            var pnl = ctl as Panel;
            if (pnl != null)
            {
                foreach(var pnlctl in pnl.Controls)
                {
                    var bt = pnlctl as Button;
                    if (bt != null)
                    {
                        // check if the Tag property of the Panel matches that of the Button
                        textbox.AppendText( pnl.Name + " = " + ((bt.Tag ==  pnl.Tag)?"OK": "Not OK") + "\r\n");                
                    }
                }
            }
       }
    }
