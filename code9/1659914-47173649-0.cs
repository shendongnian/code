    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        e.Control.KeyUp +=   new KeyEventHandler(Control_KeyUp);
    }
    
    private void Control_KeyUp(object sender, KeyEventArgs e)
    {
        //YOUR LOGIC
        // string test = dataGridView1[0, 0].EditedFormattedValue.ToString();
    }
