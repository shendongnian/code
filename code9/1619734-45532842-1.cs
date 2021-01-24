    Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
    var image = barcode.Draw(textBox1.Text, 50);
    using (var graphics = Graphics.FromImage(image))
    using (var font = new Font("Consolas", 12)) // Any font you want
    using (var brush = new SolidBrush(Color.White))
    using (var format = new StringFormat() { LineAlignment = StringAlignment.Far }) // To align text above the specified point
    {
        // Print a string at the left bottom corner of image
        graphics.DrawString(textBox1.Text, font, brush, 0, image.Height, format);
    }
    
    pictureBox1.Image = image;
