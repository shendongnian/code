    List<Bitmap> _images = new List<Bitmap>();
        int _currentImageIndex = 0;
        int CurrentImageIndex
        {
            get { return _currentImageIndex; }
            set
            {
                _currentImageIndex = value;
                if (InvokeRequired)
                {
                    Invoke(new MethodInvoker(() => { pictureBox1.Image = _images[_currentImageIndex]; });
                }
                else
                {
                    pictureBox1.Image = _images[_currentImageIndex];
                }
            }
        }
        Bitmap LoadImage(Stream stream)
        {
            return new Bitmap(stream, false);
        }
        public void LoadImages(DirectoryInfo dInfo)
        {
            foreach (FileInfo fInfo in dInfo.GetFiles())
            {
                if (InvokeRequired)
                {
                    Invoke(new MethodInvoker(() => { _images.Add(fInfo.Open(FileMode.Open)); })); //Argument 1: cannot convert from 'System.IO.FileStream' to 'System.Drawing.Bitmap'
                }
                else
                {
                    _images.Add(fInfo.Open(FileMode.Open)); //Argument 1: cannot convert from 'System.IO.FileStream' to 'System.Drawing.Bitmap'
                }
            }
        }
        void WhenTimerTicks(object sender, EventArgs e)
        {
            if (CurrentImageIndex < _images.Count)
                CurrentImageIndex++;
        }
