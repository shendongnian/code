    public void cellMouseDown(object sender, EventArgs e)
    {    
        var testbox = sender as TextBox;
    
        if (testbox != null)
        {
            testbox.BackColor = Color.Green; 
        }
    }
