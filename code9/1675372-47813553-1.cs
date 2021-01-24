            var win = new WaitWindow();
            Task.Factory.StartNew(() =>
            {
                try
                {
                    //do some long processing
                    Thread.Sleep(1000);
                }
                finally
                {
                    win.Dispatcher.Invoke(() => { win.Close(); });
                }
            });
            win.Show();
