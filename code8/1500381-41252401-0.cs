    using (Image img = Image.FromFile("yourfile.jpg"))
    using (Graphics g = Graphics.FromImage(img))
    using (SolidBrush br = new SolidBrush(Color.Black))
    {
        g.FillRectangle(br, 200, 200, 50, 50);
        img.Save("YourNewFile.jpg");
    }
