    private void Button_Click(object sender, RoutedEventArgs e)
    {
        int times = Int32.Parse(TextBox.Text);
       for (int i = 0; i < times; i++)
       {
          LoopThis();
       }
    }
