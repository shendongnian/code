    void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        // This object will have the link text in it
        // It's important to note that we are casting DataGridViewCell Class to
        // sender object
        var theComponent = (DataGridViewCell)sender;
        var val = theComponent.Value.ToString(); 
        if (string.IsNullOrEmpty(val))
        { 
            MessageBox.Show("The cell value is not assigned");
            return;
        }
 
        switch(val) 
        {
           case "http://www.mediafire.com/download/e4qd1r5r4170onj/Vert.rar":
               // Do something
               break;
           default:
               break;
        }
    }
