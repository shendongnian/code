    private void txtPath_PreviewDragOver(object sender, DragEventArgs e)
    {
        e.Handled = true;
    }
    private void txtPath_Drop(object sender, DragEventArgs e)
    {
        string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
        if (files != null && files.Length != 0)
            txtPath.Text = files[0];
    }
