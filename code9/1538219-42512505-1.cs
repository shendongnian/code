        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(() => { App.Current.Dispatcher.Invoke(async () => 
                {
                    while (this.Height < 200)
                    {
                        await Task.Delay(1000);
                        ++viewModel.Height;
                    }
                }); 
            });
        }
