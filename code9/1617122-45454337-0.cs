    private void button1_Click(object sender, EventArgs e)
    {
       if (ModifierKeys.HasFlag(Keys.Alt) || e.GetType() == typeof(MouseEventArgs))
       {
           MessageBox.Show("button is clicked.");
       }
    }    
