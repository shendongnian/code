        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10000; i++)
            {
                //Do something
                //Simulate work with Task.Delay(millisecondos)
                Label1.Content = (i * 100 / 10000) + "%";
                await Task.Yield(); //give opportunity to dispatch other events
            }
        }
