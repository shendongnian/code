    private void SomeMethod()
    {
    ...
    }
    private async void myButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            await Task.Run(someMethod);
        }
        catch(Exception e)
        {
            MessageBox.Show("SampleText");
         }
    }
