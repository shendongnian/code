        async void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window w = new ProgressWindow();
            var task = Task.Run(() => Go()).ContinueWith(completedTask =>
                {
                    Application.Current.Dispatcher.BeginInvoke(
                    DispatcherPriority.Send, new Action(() =>
                    {
                        w.Close(); 
                    }));
                    
                });
            w.ShowDialog();
            await task;
        }
