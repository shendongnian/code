    Bitmap _image;
    private void OnCreated(object source, FileSystemEventArgs e)
    {
        if (_image != null)
        {
          _image.Dispose();
          _image = null;
        }
        _image = new BitmapImage(new Uri(e.FullPath));
        image.Dispatcher.Invoke(new Action(() => { image.Source = _image; }));
    }
