    private void DragDropImage()
    {
      var filename = "filename.jpg";
      var path = Path.Combine(Path.GetTempPath(), filename);
      this.pictureBox1.Image.Save(path);
      var paths = new[] { path };
      this.pictureBox1.DoDragDrop(new DataObject(DataFormats.FileDrop, paths), DragDropEffects.Copy);
    }
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
        this.DragDropImage();
    }
