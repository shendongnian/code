    Image img = new Bitmap(1024, 1200);
    Graphics g = Graphics.FromImage(img);
    g.DrawImage(Image.FromFile("chart" + i + ".png"), new System.Drawing.Point(0, 100));
    g.DrawImage(Image.FromFile("chart2" + i + ".png"), new System.Drawing.Point(0, 600));
    img.Save("finalchart-" + i + ".png");
    img.Dispose(); // like one commenter mentioned
