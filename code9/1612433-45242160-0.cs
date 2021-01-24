    public class PlainNotifiable : INotifyPropertyChanged
    {
        private bool takeFiveSeconds;
        private bool takeTenSeconds;
        public event PropertyChangedEventHandler PropertyChanged;
        public bool TakeFiveSeconds
        {
            get => this.takeFiveSeconds;
            set
            {
                this.takeFiveSeconds = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.TakeFiveSeconds)));
            }
        }
        public bool TakeTenSeconds
        {
            get => this.takeTenSeconds;
            set
            {
                this.takeTenSeconds = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.TakeTenSeconds)));
            }
        }
        public async Task TakeSomeTime(int seconds, CancellationToken token = default(CancellationToken))
        {
            Trace.TraceInformation("Started waiting {0} seconds", seconds);
            await Task.Delay(seconds * 1000, token);
            Trace.TraceInformation("Stoped waiting {0} seconds", seconds);
        }
    }
    public static async void Test()
    {
        var test = new PlainNotifiable();
        async Task<Unit> propertyNameToLongTask(EventPattern<PropertyChangedEventArgs> args, CancellationToken token)
        {
            switch (args.EventArgs.PropertyName)
            {
                case nameof(test.TakeFiveSeconds):
                    await test.TakeSomeTime(5, token);
                    break;
                case nameof(test.TakeTenSeconds):
                    await test.TakeSomeTime(10, token);
                    break;
            }
            return Unit.Default;
        }
        Observable.FromEventPattern<PropertyChangedEventArgs>(test, nameof(test.PropertyChanged))
            .Select(x => Observable.FromAsync(token => propertyNameToLongTask(x, token)))
            .Switch()
            .Subscribe(x => Trace.TraceInformation("Beep boop"));
        Trace.TraceInformation("Started sending notifications");
        await Task.Delay(1000);
        test.TakeTenSeconds = true;
        await Task.Delay(2000);
        test.TakeFiveSeconds = true;
        Trace.TraceInformation("Finished sending notifications");
    }
