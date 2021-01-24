        Mat lena = new Mat(@"D:\OpenCV\opencv-3.2.0\samples\data\Lena.jpg", 
                           ImreadModes.Unchanged);
        CvInvoke.Imshow("Lena", lena);
        System.Drawing.Rectangle topRect = new Rectangle(0, 
                                                         0, 
                                                         lena.Width,
                                                         (lena.Height / 2));
        System.Drawing.Rectangle bottomRect = new Rectangle(0, 
                                                            (lena.Width / 2),
                                                            lena.Width,
                                                            (lena.Height / 2));
        Mat lenaTop = new Mat(lena, topRect);
        CvInvoke.Imshow("Lena Top", lenaTop);
        Mat lenaBottom = new Mat(lena, bottomRect);
        CvInvoke.Imshow("Lena Bottom", lenaBottom);
        Mat newLena = new Mat();
        CvInvoke.VConcat(lenaBottom, lenaTop, newLena);
        CvInvoke.Imshow("New Lena", newLena);
        CvInvoke.WaitKey(0);
