    private void Button_Click(object sender, RoutedEventArgs e)
    {
       int times;
       if (Int32.TryParse(TextBox.Text, out times))
       {
           // It could parse the input text (so we deduce it was an integer)
           // and not a string.
           for (int i = 0; i < times; i++)
           {
               LoopThis();
           }
       }
       else
       {
          // Throw exception or show a message to the user
       }
    }
