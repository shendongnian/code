    private void CopyScreen()
    {
        var picBox = pictureBox;
        var bit = new Bitmap(this.Width, this.Height);
        using (var g = Graphics.FromImage(bit))
        {
            var upperLeftSource = new Point(
                Screen.PrimaryScreen.Bounds.Width / 2 - this.Width / 2,
                Screen.PrimaryScreen.Bounds.Height / 2 - this.Height / 2);
            g.CopyFromScreen(upperLeftSource, new Point(0, 0), bit.Size);
            var oldImage = picBox.Image;
            picBox.Image = bit;
            oldImage?.Dispose();
        }
    }
