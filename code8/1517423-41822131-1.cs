    public partial class MainWindow : Window
    {
        private readonly WriteableBitmap bitmap
            = new WriteableBitmap(100, 100, 96, 96, PixelFormats.Bgr32, null);
        public MainWindow()
        {
            InitializeComponent();
            image.Source = bitmap;
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(0.1) };
            timer.Tick += OnTimerTick;
            timer.Start();
        }
        private unsafe void OnTimerTick(object sender, EventArgs e)
        {
            int pixelValue = (int)DateTime.Now.Ticks & 0xFFFFFF;
            bitmap.Lock();
            var backBuffer = bitmap.BackBuffer;
            for (int y = 0; y < bitmap.PixelHeight; y++)
            {
                for (int x = 0; x < bitmap.PixelWidth; x++)
                {
                    var bufPtr = backBuffer + bitmap.BackBufferStride * y + x * 4;
                    *((int*)bufPtr) = pixelValue;
                }
            }
            bitmap.AddDirtyRect(new Int32Rect(0, 0, bitmap.PixelWidth, bitmap.PixelHeight));
            bitmap.Unlock();
        }
    }
