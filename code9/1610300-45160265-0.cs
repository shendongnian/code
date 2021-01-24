    gray = grabber.QueryGrayFrame().Resize(320, 240, 
    Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
    MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
            face,
            1.2,
            10,
            Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
            new Size(20, 20));
    foreach (MCvAvgComp f in facesDetected[0])
    {
    TrainedFace = currentFrame.Copy(f.rect).Convert<Gray, byte>();
    TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
    trainingImages.Add(TrainedFace);
    }
     for (int i = 1; i < trainingImages.ToArray().Length + 1; i++)
    {
        trainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/TrainedFaces/face" + i + ".bmp");
     }
