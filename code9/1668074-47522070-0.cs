    Image img = Clipboard.GetImage();
    if (img != null) {
      ColorMap[] cm = new ColorMap[1];
      cm[0] = new ColorMap();
      cm[0].OldColor = Color.Black;
      cm[0].NewColor = Color.White;
      ImageAttributes ia = new ImageAttributes();
      ia.SetRemapTable(cm);
      using (Graphics g = Graphics.FromImage(img)) {
        g.DrawImage(img, new Rectangle(Point.Empty, img.Size), 0, 0, img.Width, img.Height,
                    GraphicsUnit.Pixel, ia);
      }
      pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
      pictureBox1.Image = img;
    }
