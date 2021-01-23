    private void ClickNewBar (object sender, RoutedEventArgs e)
    {
        if (list.Count < MAX_ADDRESS_BARS)
        {                
            list.Add(new AModel()
                {
                    Text = "",
                    ICommand = SomeCommand
                });
        }
        else
        {
            MessageBox.Show (ErrorMessages.MAX_ITEMS);
        }
    }
