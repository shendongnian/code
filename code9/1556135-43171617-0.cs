    private async void New_Background(object sender, BackgroundEventArgs e)
    {
        await Task.Delay(1000);
        Application.Current.Dispatcher.Invoke(new Action(async () =>
        {
            Fields[e.Position].Background = e.Background; //update this position's background at every step
            OnPropertyChanged("Background");
        }));
    }
