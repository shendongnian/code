    private void PictureBox_MouseDown(object sender, MouseEventArgs e)
    {
        var info = new FileInfo(_filename);
        string[] paths = { info.FullName };
        var pictureBox = (PictureBox)sender;
        pictureBox.DoDragDrop(new DataObject(DataFormats.FileDrop, paths), DragDropEffects.Copy);
    }
