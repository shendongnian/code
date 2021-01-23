    TextBox TextBoxObject; // this will be global
    
    // Event handler for all button
    private void btnW_Click(object sender, EventArgs e)
    {
       if(TextBoxObject!=null)
       {
          TextBoxObject.Text += btnW.Text;   // This will add the character at the end of the current text
          // if you want to Add at the current position means use like this
            int currentIndex = TextBoxObject.SelectionStart;
          TextBoxObject.Text = TextBoxObject.Text.Insert(currentIndex, btnW.Text);
       }
    }
