    private void inputSequencial_KeyPress(object sender, KeyPressEventArgs e)
    {
       //Allow only digits(char 48 à 57), hyphen(char 45), backspace(char 8) and delete(char 127)
       if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 45 || e.KeyChar == 8 || e.KeyChar == 127)
       {    
          switch (e.KeyChar)
          {
             case (char)45:
             int count = inputSequencial.Text.Split('-').Length - 1;
             //If the first char is a hyphen or 
             //a hyphen already exists I reject the entry
             if (inputSequencial.Text.Length == 0 || count > 0)
             {
                e.Handled = true;
             }
             break;
          }
       }
       else
       {
          e.Handled = true; //Reject other entries
       }
    }
    
    private void inputSequencial_KeyUp(object sender, KeyEventArgs e)
    {
       //if last char is a hyphen i replace it.
       if (inputSequencial.Text.Length > 1)
       {
          string lastChar = inputSequencial.Text.Substring(inputSequencial.Text.Length - 1, 1);
          if (lastChar == "-")
          {
             inputSequencial.Text.Replace("-", "");
          }
       }
    }
