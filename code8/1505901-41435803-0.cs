    PictureBox newPictureBox(Image image, int X, int Y) {
        return new PictureBox() {
            Image = image,
            Size = new Size(22, 22),
            Location = new Point(X, Y),
            SizeMode = PictureBoxSizeMode.StretchImage
        };
    }
