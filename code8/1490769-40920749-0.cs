    private static string TextBoxDefaultValue = "Welcome";
  
    private void textbox1_IsChanged(object sender, KeyEventArgs e)
    {
        if (!string.IsNullOrWhitespace(TextBox1.Text) ||
            TextBox1.Text == TextBoxDefaultValue )
        {
          SaveButton.IsEnabled = false;
    
          if (WpfHelpers.Confirmation(resources.QuitWithoutSaving, resources.Changes))
          {
      
          }
        }
    }
