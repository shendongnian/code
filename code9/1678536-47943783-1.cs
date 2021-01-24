    private void check_Click(object sender, EventArgs e)
    {
        textbox.Text = "";
       
        // loop over all controls of the Form
        foreach(var ctl in Controls)
        {
            var pnl = ctl as Panel;
            if (pnl != null)
            {
                // loop over the Controls in a Panel
                foreach(var pnlctl in pnl.Controls)
                {
                    // find any buttons
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
