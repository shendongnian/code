    class CameraViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Camera camera = new Camera();
        private BitmapSource currentCameraImage;
        public BitmapSource CurrentCameraImage
        {
            get { return currentCameraImage; }
            set
            {
                currentCameraImage = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("CurrentCameraImage"));
            }
        }
        public async Task StartCamera()
        {
            await Task.Run(async () =>
            {
                while (true)
                {
                    BitmapSource bitmap;
                    camera.GetImage(out bitmap, 1000); // from API
                    bitmap.Freeze(); // make bitmap cross-thread accessible
                    CurrentCameraImage = bitmap;
                }
            });
        }
    }
