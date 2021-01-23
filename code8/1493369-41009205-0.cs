    protected void urlTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                string theText = textBox.Text;
                var item = (RepeaterItem) textBox.NamingContainer;
                if(item != null) {
                   Label titleLabel = (Label)item.FindControl("title");
                   if(titleLabel != null) {
                      titleLabel.Text = theText;
                   }
                }
            }
    
        }
