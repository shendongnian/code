    public class AutoUpdatingItem : INotifyPropertyChanged
    {
        private readonly DispatcherTimer timer;
        private int data;
        public int Data
        {
            get { return data; }
            set 
            { 
                data = value; 
                propertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Data))); 
            }
        }
        public AutoUpdatingItem()
        {
            timer = new DispatcherTimer(new TimeSpan(0,0,0,0,200), DispatcherPriority.Background, Tick, Dispatcher.CurrentDispatcher);
            timer.Stop();
        }
        private void Tick(object sender, EventArgs e)
        {
            Data++;
        }
        private event PropertyChangedEventHandler propertyChanged;
        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                propertyChanged += value;
                timer.Start();
            }
            remove
            {
                timer.Stop();
                propertyChanged -= value;
            }
        }
    }
