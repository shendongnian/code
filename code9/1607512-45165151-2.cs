        private List<Image<Bgr, Byte>> GetVideoFrames(String Filename,int secondsToSkip)
        {
            try
            {
                List<Image<Bgr, Byte>> image_array = new List<Image<Bgr, Byte>>();
                _capture = new Capture(Filename);
                double fps = _capture.GetCaptureProperty(Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FPS);
                Image<Bgr, Byte> frame = null;
                bool reading = true;
                double framesToSkip = secondsToSkip * fps;
                for (int count=1; reading; count++)
                {
                    if(count%framesToSkip != 0)
                        _capture.QuerySmallFrame(); 
                    else
                    { 
                        frame = _capture.QueryFrame();
                        reading = (frame != null);
                        if (reading)
                        {
                            image_array.Add(frame.Copy());
                            image_array[count].Save(@"D:\SVN\Video Labeling\Images\" + count + ".png");
                        }
                    }
                }
                return image_array;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
