    NumericUpDownEditingControl lastCtl = null;
    EventHandler handler = null;
    private void Grid1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        var ctl = e.Control as NumericUpDownEditingControl;
        if (ctl != null && ctl != lastCtl)
        {
            lastCtl = ctl;
            if (handler == null) handler = new EventHandler(myUpDownCtl_ValueChanged);
            lastCtl.ValueChanged -= handler;
            lastCtl.ValueChanged += handler;
        }
    }
    void myUpDownCtl_ValueChanged(object sender, EventArgs e)
    {
        MessageBox.Show("New value: " + lastCtl.Value.ToString());
        //Grid1.CurrentRow.Cells[5].Value = lastCtl.Value * 10; //sample to change other columns based on this value
    }
