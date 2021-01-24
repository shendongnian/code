        private async void Button1_Click(object sender, RoutedEventArgs e)
        {
            _sw = new Stopwatch();
            _sw.Start();
            Label1.Content = "Working...";
            var buttonContent = ((Button) sender).Content
            var w1 = Task.Run(() => Work1(buttonContent));
            var w2 = Task.Run(() => Work2(buttonContent));
            await Task.WhenAll(w1, w2);
            // back on UI-context here
            UpdateLabel();
        }
