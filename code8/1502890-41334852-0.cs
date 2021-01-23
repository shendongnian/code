    private void Window_MouseMove(object sender, MouseEventArgs e)
    {
        if (_dragged == null)
            return;
        if (e.LeftButton == MouseButtonState.Released)
        {
            _dragged = null;
            return;
        }
        DataObject obj = new DataObject(DataFormats.Serializable, _dragged.DataContext as ListBoxFileName);
        DragDrop.DoDragDrop(_dragged, obj, DragDropEffects.All);
    }
    private void FileListBox_Drop(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.Serializable, true))
        {
            ListBoxFileName BoxItem = e.Data.GetData(DataFormats.Serializable) as ListBoxFileName;
            //...
        }
    }
