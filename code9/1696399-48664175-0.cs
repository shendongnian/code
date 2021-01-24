    private async Task CreateTableAsync(string tableName)
    {
        //Execute SQL code that creates a table
        using(var connection=new SqlConnection(_connString)
        using(var cmd=new SqlCommand(connection,sql))
        {
            ....
            await cmd.ExecuteNonQueryAsync();
        }
    }
    private async void MyButton_Click(object sender, EventArgs args)
    {
        Color redColor = (Color)ColorConverter.ConvertFromString("#DDC31616");
        Color greenColor = (Color)ColorConverter.ConvertFromString("#DD15992D");
        tableIcon.Visibility = Visibility.Collapsed;
        tableIconLoading.Visibility = Visibility.Visible;
        try 
        {
            await CreateTableAsync("SomeTableName");
            tableIcon.Foreground = new SolidColorBrush(greenColor);
            tableIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.CheckCircle;
            tableIconLoading.Visibility = Visibility.Collapsed;
            tableIcon.Visibility = Visibility.Visible;
        }
        catch(Exception exc)
        {
            MessageBox.Show(exc.ToString(),"Ouch!");
        }
    }
