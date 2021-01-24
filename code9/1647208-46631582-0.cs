    public class Model
    {
        private readonly Random random = new Random();
        public Color Color { get; private set; }
        public void UpdateColor()
        {
            Color = Color.FromRgb(
                (byte)random.Next(256), (byte)random.Next(256), (byte)random.Next(256));
        }
    }
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Model Model { get; } = new Model();
        private Brush brush;
        public Brush Brush
        {
            get { return brush; }
            set
            {
                brush = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Brush)));
            }
        }
        public ViewModel()
        {
            var timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(0.1)
            };
            timer.Tick += (s, e) =>
            {
                Model.UpdateColor();
                Brush = new SolidColorBrush(Model.Color);
            };
            timer.Start();
        }
    }
  
