    protected void Page_Load(object sender, EventArgs e) 
    {
        var image = new Bitmap(800, 600);
        try 
        {
            var graph = Graphics.FromImage(image);
            graph.FillRectangle(Brushes.White, new Rectangle(new Point(0, 0), image.Size));
            for (int col = 0; col < image.Width; col += 100) {
                graph.DrawLine(Pens.Black, new Point(col, 0), new Point(col, image.Height));
            }
            for (int row = 0; row < image.Height; row += 30) {
                graph.DrawLine(Pens.Black, new Point(0, row), new Point(image.Width, row));
            }
            graph.DrawRectangle(Pens.Black, new Rectangle(0, 0, image.Width - 1, image.Height - 1));
    
            Response.Clear();
            Response.ContentType = "image/jpeg";
            image.Save(Response.OutputStream, ImageFormat.Jpeg);
            Response.End();
        } 
        finally 
        {
            image.Dispose();
        }
    }
