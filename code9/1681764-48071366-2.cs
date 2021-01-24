    public async Task populate_data()
    {
        CityList.Clear();
        const int count = 5000;
        const int batch = 50;
        int iterations = count / batch, remainder = count % batch;
        Random rnd = new Random();
        for (int i = 0; i < iterations; i++)
        {
            int thisBatch = _GetBatchSize(batch, ref remainder);
            for (int j = 0; j < batch; j++)
            {
                int x = rnd.Next(65, 125);
                int y = rnd.Next(25, 50);
                int popoulation = rnd.Next(50, 200);
                string name = x.ToString() + "," + y.ToString();
                CityList.Add(new City(name, x, y, popoulation));
            }
            await Dispatcher.InvokeAsync(() => { }, DispatcherPriority.ApplicationIdle);
        }
    }
    private static int _GetBatchSize(int batch, ref int remainder)
    {
        int thisBatch;
        if (remainder > 0)
        {
            thisBatch = batch + 1;
            remainder--;
        }
        else
        {
            thisBatch = batch;
        }
        return thisBatch;
    }
    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        Stopwatch sw = Stopwatch.StartNew();
        await populate_data();
        ElapsedToIdle = sw.Elapsed;
        ButtonEnabled = true;
    }
