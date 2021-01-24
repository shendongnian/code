       private void ButtonClicked(object sender, RoutedEventArgs e) {
            Task.Run(() =>
            {
                for (int i = 0; i < 300000; i++) {
                    tbxResult.Dispatcher.Invoke(() => {
                        tbxResult.AppendText("testMessage" + i + "\r\n");
                    }, DispatcherPriority.Background);
                }
            });
        }
