    public void DetectCorners()
    {
        // Load image and create everything you need for drawing
    	Bitmap image = new Bitmap(@"C:\Users\ssammour\Desktop\Unbenannt.PNG");
    	BlobCounter blobCounter = new BlobCounter();
        blobCounter.ProcessImage(image);
    	Bitmap result = new Bitmap(image.Width, image.Height, Graphics.FromImage(image));
    	Graphics g = Graphics.FromImage(result);
    	g.DrawImage(image,0,0);
        Blob[] blobs = blobCounter.GetObjectsInformation();
        SimpleShapeChecker shapeChecker = new SimpleShapeChecker();
        Pen redPen = new Pen(Color.Red);
        for (int i = 0, n = blobs.Length; i < n; i++)
        {
            List<IntPoint> corners;
            List<IntPoint> edgePoints = blobCounter.GetBlobsEdgePoints(blobs[i]);
    
            if (shapeChecker.IsQuadrilateral(edgePoints, out corners))
            {
    			corners.Dump();
                g.DrawPolygon(redPen, ToPointsArray(corners, image.Height));
            }
        }
        result.Save(@"c:\result.png", ImageFormat.Png);
    }
