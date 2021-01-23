    async void Button_Click(object sender, RoutedEventArgs e)
    {
         if (_semaphore.Wait(0))
         {
            await Test(); // moving code into separate method
            _semaphore.Release();
        }
    }
