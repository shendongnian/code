    Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
    var barcodeImage = barcode.Draw(textBox1.Text, 50);
    var resultImage = new Bitmap(barcodeImage.Width, barcodeImage.Height + 20); // 20 is bottom padding, adjust to your text
    using (var graphics = Graphics.FromImage(resultImage))
    using (var font = new Font("Consolas", 12))
    using (var brush = new SolidBrush(Color.Black))
    using (var format = new StringFormat()
    {
        Alignment = StringAlignment.Center, // Also, horizontally centered text, as in your example of the expected output
        LineAlignment = StringAlignment.Far
    })
    {
        graphics.Clear(Color.White);
        graphics.DrawImage(barcodeImage, 0, 0);
        graphics.DrawString(textBox1.Text, font, brush, resultImage.Width / 2, resultImage.Height, format);
    }
    pictureBox1.Image = resultImage;
