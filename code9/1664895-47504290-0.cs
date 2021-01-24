    class MainViewModel: ViewModelBase
    {
        private Bitmap Img;
        public ICommand OpenImg { get; set; }
        public MainViewModel()
        {
            OpenImg = new RelayCommand(openImg, (obj) => true);
        }
        private void openImg(object obj = null)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png;*.bmp;*.tiff|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                ImgPath = op.FileName;
                Img = new Bitmap(ImgPath);
            }
        }
        private string _ImgPath;
        public string ImgPath
        {
            get { return _ImgPath; }
            set
            {
                _ImgPath = value;
                OnPropertyChanged("ImgPath");
            }
        }
        private ICommand _mouseMoveCommand;
        public ICommand MouseMoveCommand
        {
            get
            {
                if (_mouseMoveCommand == null)
                {
                    _mouseMoveCommand = new RelayCommand(param => ExecuteMouseMove((MouseEventArgs)param));
                }
                return _mouseMoveCommand;
            }
            set { _mouseMoveCommand = value; }
        }
        private void ExecuteMouseMove(MouseEventArgs e)
        {
            System.Windows.Point p = e.GetPosition(((IInputElement)e.Source));
            if ((p.X >= 0) && (p.X < Img.Width) && (p.Y >= 0) && (p.Y < Img.Height))
            {
                Color color = Img.GetPixel((int)p.X, (int)p.Y);
                int r = color.R;
                int g = color.G;
                int b = color.B;
                float hue = color.GetHue();
                float saturation = color.GetSaturation();
                float brightness = color.GetBrightness();
                XY = String.Format("X: {0} Y: {1}", (int)p.X, (int)p.Y);
                RGB = String.Format("R: {0} G: {1} B: {2}", r.ToString(), g.ToString(), b.ToString());
                HSI = String.Format("H: {0} S: {1:0.000} I: {2:0.000}", (int)hue, saturation, brightness);
            }
        }
        private string xy;
        public string XY
        {
            get { return xy; }
            set
            {
                xy = value;
                OnPropertyChanged("XY");
            }
        }
        private string rgb;
        public string RGB
        {
            get { return rgb; }
            set
            {
                rgb = value;
                OnPropertyChanged("RGB");
            }
        }
        private string hsi;
        public string HSI
        {
            get { return hsi; }
            set
            {
                hsi = value;
                OnPropertyChanged("HSI");
            }
        }
        private ICommand _mouseLeaveCommand;
        public ICommand MouseLeaveCommand
        {
            get
            {
                if (_mouseLeaveCommand == null)
                {
                    _mouseLeaveCommand = new RelayCommand(param => ExecuteMouseLeave((MouseEventArgs)param));
                }
                return _mouseLeaveCommand;
            }
            set { _mouseLeaveCommand = value; }
        }
        private void ExecuteMouseLeave(MouseEventArgs e)
        {
            XY = string.Empty;
            RGB = string.Empty;
            HSI = string.Empty;
        }
    }
