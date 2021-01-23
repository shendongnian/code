    button.Click += MyButtonClick;
    
    private async void MyButtonClick(object sender, EventArgs e)
    {
        button.Text="Working";
        await Task.Run(() =>
        {
            Task.Delay(3000).Wait(); //or whatever you need
        });
        button.Text="Done";
    }
