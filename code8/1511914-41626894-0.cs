        public WindowMain()
    {
        InitializeComponent();
    
        // your code, etc.
    
        scrollViewer.AllowDrop = true;
        scrollViewer.PreviewDragEnter += scrollViewer_PreviewDragEnter;
        scrollViewer.PreviewDragOver += scrollViewer_PreviewDragOver;
        scrollViewer.Drop += scrollViewer_Drop;
    }
    
    
    void scrollViewer_PreviewDragEnter(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.FileDrop))
        {
            e.Effects = DragDropEffects.Copy;
        }
        else
        {
            e.Effects = DragDropEffects.None;
        }
    }
    
    void scrollViewer_PreviewDragOver(object sender, DragEventArgs e)
    {
        e.Handled = true;
    }
    
    bool IsDataAvailable = false;
    void scrollViewer_Drop(object sender, DragEventArgs e)
    {
        // Get data object
        var dataObject = e.Data as DataObject;
    
        // Check for file list
        if (dataObject.ContainsFileDropList())
        {
            // Process file names
            StringCollection fileNames = dataObject.GetFileDropList();
            bool isIsDataAvailable = false;
            try
            {
                var uri = new Uri(fileNames[0]);
                BitmapSource imageSource = new BitmapImage(uri);
                isIsDataAvailable = true;
            }
            catch (Exception error)
            {
                string errorMessage = error.ToString();
            }
            finally
            {
                IsDataAvailable = isIsDataAvailable;
            }
        }
    }
