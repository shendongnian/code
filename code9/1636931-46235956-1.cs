    Image<Gray,byte> imageFullSize = new Image<Gray, byte>(imagePath);
    Rectangle roi = new Rectangle(Your Top Left X,Your Top Left Y,Your ROI Width,Your ROI Height);
    //Now get a roi (No copy, it is a new header pointing original image
    Image<Gray,byte> image = imageFullSize.GetSubRect(roi);
    //Step 1 : contour detection using canny
    //Gaussian noise removal, eliminate background false détections
    image._SmoothGaussian(15);
    //Canny thresh based on otsu threshold value: 
    Mat binary = new Mat();
    double otsuThresh = CvInvoke.Threshold(image, binary, 0, 255, ThresholdType.Binary | ThresholdType.Otsu);
    double highThresh = otsuThresh;
    double lowThresh = otsuThresh * 0.5;
    var cannyImage = image.Canny(lowThresh, highThresh);   
    //Step 2 : contour extraction
    Mat hierarchy=new Mat();
    VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
    CvInvoke.FindContours(cannyImage,contours,hierarchy,RetrType.External,ChainApproxMethod.ChainApproxSimple);
    //Step 3 : contour fusion
    List<Point> points=new List<Point>();
    for(int i = 0; i < contours.Size; i++)
    {
        points.AddRange(contours[i].ToArray());
    }
            
    //Step 4 : Rotated rect
    RotatedRect minAreaRect = CvInvoke.MinAreaRect(points.Select(pt=>new PointF(pt.X,pt.Y)).ToArray());
    Point[] vertices = minAreaRect.GetVertices().Select(pt => new Point((int)pt.X, (int)pt.Y)).ToArray();
    //Step 5 : draw result
    Image <Bgr,byte > colorImageFullSize =new Image<Bgr, byte>(imagePath);
    Image <Bgr,byte > colorImage =colorImageFullSize.GetSubRect(roi);
    colorImage.Draw(vertices,new Bgr(Color.Red),2 );
