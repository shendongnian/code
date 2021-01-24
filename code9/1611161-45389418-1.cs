    void timer_Tick(object sender, EventArgs e)
    {
      Image<Bgr,Byte> currentFrame = capture.QueryFrame();
      if (currentFrame != null)
      {
        Image<Gray, Byte> grayFrame = currentFrame.Convert<Gray, Byte>();
      
        var detectedFaces = grayFrame.DetectHaarCascade(haarCascade)[0];
        
        foreach (var face in detectedFaces)
          currentFrame.Draw(face.rect, new Bgr(0, double.MaxValue, 0), 3);
      
        // derectedFaces[x].rect containes the rectangles around the faces
        // currentFrame have the image with marked faces
      }  
    }
