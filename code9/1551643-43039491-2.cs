    var pen = new Pen(Color.Black, 1);
    // draws all rectangles on the image
    annotationAOIs.ForEach(a =>
    {
        g.DrawRectangle(pen, a.Start.X, a.Start.Y, (a.End.X - a.Start.X), (a.End.Y - a.Start.Y));
    });
    g.Dispose(); // disposes used graphics
    ImageBackup = new Bitmap(im); // backup image with rectangles
