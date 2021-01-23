    foreach (FileInfo files in folder.GetFiles())
    {
        System.Diagnostics.Debug.Print(files.Extension);
        bool isJPG = string.Equals(files.Extension, ".jpg", StringComparison.OrdinalIgnoreCase);
        bool isPNG = string.Equals(files.Extension, ".png", StringComparison.OrdinalIgnoreCase);
        bool isGIF = string.Equals(files.Extension, ".gif", StringComparison.OrdinalIgnoreCase);
        if (isJPG || isPNG || isGIF)
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
