    public Task SetPrintFillAsync()
    {
        return this.Dispatcher.RunAsync(CoreDispatcherPriority.High, () =>
        {
            Debug.WriteLine("I'm inside the printer before");
            this.staffImageBorder.Fill = new SolidColorBrush(Colors.Blue);
            Debug.WriteLine("I'm inside the printer after");
        });
    }
