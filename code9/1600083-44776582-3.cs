    void newButton(object sender, EventArgs e)
    {
        if(sender is Button btn) 
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
