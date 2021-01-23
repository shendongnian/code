    private void Button_Click(object sender, RoutedEventArgs e)
    {
        int count = 100000;
        Task.Factory.StartNew(() => {
            for (int i = 0; i < count; i++)
            {
                this.Dispatcher.BeginInvoke(new Action(() => {
                    CreateCtr(i.ToString());
                }));
                Thread.Sleep(5);
            }
        });
    }
