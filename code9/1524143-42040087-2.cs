    List<Bitmap> _images = new List<Bitmap>();
    int _currentImageIndex = 0;
    int CurrentImageIndex
    {
        get { return _currentImageIndex; }
        set {
            _currentImageIndex = value;
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker( () => { _pictureBox.Image = _images[_currentImageIndex]; } );
            }
            else 
            {
                _pictureBox.Image = _images[_currentImageIndex];
            }
        }
    }
    Bitmap LoadImage(Stream stream)
    {
        return new Bitmap(stream, false);
    }
    public void LoadImages(DirectoryInfo dInfo)
    {
        foreach(FileInfo fInfo in dInfo.GetFiles())
        {
            if(InvokeRequired)
            {
                Invoke(new MethodInvoker( () => { _images.Add(LoadImage (fInfo.Open(FileMode.Open))); });
            }
            else
            {
                _images.Add(LoadImage (fInfo.Open()));
            }
        }
    }
    void WhenTimerTicks(object sender, EventArgs e)
    {
        if(CurrentImageIndex < _images.Count)
            CurrentImageIndex++;
    }
