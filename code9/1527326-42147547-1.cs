        private async void Button1_Click(object sender, RoutedEventArgs e)
        {
            _sw = new Stopwatch();
            _sw.Start();
            Label1.Content = "Working...";
            var buttonContent = ((Button) sender).Content
            // this will work too
            // consider to rename your button
            // var buttonContent = Button1.Content
            // save the context and return here after task is done
            await Task.Run(() =>
            {
                Parallel.Invoke(() => Work1(buttonContent),
                                () => Work2(buttonContent));
            });
            // back on UI-context here
            UpdateLabel();
        }
