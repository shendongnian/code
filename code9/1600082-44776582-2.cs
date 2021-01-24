    void newButton(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        // btn could be null if the event handler would be 
        // also triggered by other controls e.g. a label
        if(btn != null) 
        {
            if (btn.Name == "btn1")
            {
                MessageBox.Show("btn1");          
            }
            if (btn.Name == "btn2")
            {
                MessageBox.Show("btn2");
            }
        }
    }
