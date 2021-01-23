    private void label1_Click(object sender, EventArgs e)
    {
        TextBox tb = null;
        if (label1.Controls.Count > 0)  // do we already have created our TextBox?
        {
            tb = ((TextBox)label1.Controls[0]);  // yes. set reference.
            // is it already visible? we got clicked from outside, so we hide it:
            if (tb.Visible) { label1.Text = tb.Text; tb.Hide(); return; };
        }
        else if (sender == null) return;  // clicked from outside: do nothing
             else  // we need to create the textbox
             {
               tb = new TextBox();
               tb.Parent = label1;     // add it to the label's Controls collection
               tb.Size = label1.Size;  // size it
               // set the event that ends editing when focus goes elsewhere:
               tb.LostFocus += (ss, ee) =>   { label1.Text = tb.Text; tb.Hide(); };
             }
 
        tb.Text = label1.Text;  // get current text
        tb.Show();              // display the textbox in place
    }
