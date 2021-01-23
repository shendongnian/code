    private void Window_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
    {
        // lets say pw is "1" for testing purposes
        if (e.Key == Key.Enter && lblPasswordBox.Password == "1")
        {
            this.DialogResult = true;
            this.Close();
        }
    }
