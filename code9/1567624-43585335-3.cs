    Bitmap b = (Bitmap)Image.FromFile(fileName);
    // the data array sizes:
    int numX = 3000;
    int numY = 30;
    int[,] data = new int[numX, numY];
 
    // create test data:
    Random rnd = new Random(8);
    for (int i = 0; i < data.GetLength(0); i++)
         for (int j = 0; j < data.GetLength(1); j++)
              data[i, j] = rnd.Next(123456);
    // scale the tile size:
    float sx =  1f * b.Width / data.GetLength(0);
    float sy =  1f * b.Height / data.GetLength(1);
    // now fill the tile-pixels
    using (Graphics g = Graphics.FromImage(b))
    {
        for (int x = 0; x < data.GetLength(0); x++)
            for (int y = 0; y < data.GetLength(1); y++)
            {
                RectangleF r = new RectangleF(x * sx, y* sy, sx, sy);
                Color c = Color.FromArgb(99, Color.FromArgb(data[x, y]));
                using (SolidBrush brush = new SolidBrush(c))
                    g.FillRectangle(brush, r);
            }
        // display or save or whatever..
        pictureBox1.Image = b;
    }
