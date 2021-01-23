    public void checker(TextBox txtBox)
    {
       if(textbox == null)
       {
          return;
        }
    
        if(txtBox.Text == "")
        {
           txtBox.BackColor = Color.Red;
        }
        else
        {
          txtBox.BackColor = Color.White;
        }
    
    }
    public void textbox_TextChanged(object sender,EventArgs e)
    {
         checker(sender as TextBox);
    }
