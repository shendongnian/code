    Mat matFrame = capture.QueryFrame();
    Image<Bgr, byte> nextFrame = matFrame.ToImage<Bgr, byte>()
    Image<Gray, byte> grayframe = nextFrame.Convert<Gray, byte>();
   
    var faces = haar.DetectMultiScale( matFrame, 1.1, 10, 
                      Emgu.CV.CvEnum.HaarDetectionType.DoCannyPruning,  
                      new Size(20, 20));
