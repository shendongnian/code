    ThreadPool.QueueUserWorkItem(
        o =>
        {
            int a = 0;
            for (int i = 0; i < 10000000000; i++)
            {
                a = a + i;
                FaturaCount.Dispatcher.Invoke(() =>
                {
                    txtCount.Text = a.ToString();
                });
            }
        });
