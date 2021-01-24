    NumericUpDownEditingControl lastCtl = null;
    EventHandler handler = null;
    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        var ctl = e.Control as NumericUpDownEditingControl;
        if (ctl != null) //&& ctl != lastCtl
        {
            if (handler == null) handler = new EventHandler(myUpDownCtl_ValueChanged); //save a handler has better performance
            //Event => ValueChanged: just fires for Up/Dn btn or when press enter, TextChanged: also fired during user typing
            if (lastCtl != null) lastCtl.ValueChanged -= handler; //ensure we remove our handler. 
            lastCtl = ctl;
            lastCtl.ValueChanged += handler; //we can use myUpDownCtl_ValueChanged directly instead of that handler var
            //handler(sender, EventArgs.Empty);
        }
    }
    void myUpDownCtl_ValueChanged(object sender, EventArgs e)
    {
        MessageBox.Show("New value: " + lastCtl.Value.ToString());
        //Grid1.CurrentRow.Cells[5].Value = lastCtl.Value * 10; //sample to change other columns based on this value
    }
