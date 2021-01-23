    foreach (FileInfo files in folder.GetFiles())
    {
        System.Diagnostics.Debug.Print(files.Extension);
        if ((string.Equals(files.Extension, ".jpg", StringComparison.OrdinalIgnoreCase)) || (string.Equals(files.Extension, ".gif", StringComparison.OrdinalIgnoreCase)) || (string.Equals(files.Extension, ".png", StringComparison.OrdinalIgnoreCase)))
        {
            using (var stream = new FileStream(files.FullName, FileMode.Open))
            {
                PictureBox image = new PictureBox();
                image.Image = Image.FromStream(stream);
                image.SizeMode = PictureBoxSizeMode.Zoom;
                image.Size = this.Size;
                imagePanel.Controls.Add(image);
            }
        }
    }
