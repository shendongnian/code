    private void form1_KeyDown(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {        
        if (e.Key == Key.Right)
        {
            date_down = DateTime.Now;
        }
        e.Handled = true;
    }
    private void form1_KeyUp(object sender, System.Windows.Forms.KeyPressEventArgs e)
    { 
        if (e.Key == Key.Right)
        {
            var timeDelta = DateTime.Now - date_down;
        }
    }
