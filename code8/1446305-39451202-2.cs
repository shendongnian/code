    BitmapImage _image;
    private void OnCreated(object source, FileSystemEventArgs e)
    {
        if (_image != null)
        {
          FreeMemoryAcquiredByImage(_image);
          _image = null;
        }
        _image = new BitmapImage(new Uri(e.FullPath));
        //You may have to freeze _image here.
        image.Dispatcher.Invoke(new Action(() => { image.Source = _image; }));
    }
