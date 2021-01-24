        private List<Image<Bgr, Byte>> GetVideoFrames(String Filename,int framesToSkip)
        {
            try
            {
                List<Image<Bgr, Byte>> image_array = new List<Image<Bgr, Byte>>();
                _capture = new Capture(Filename);
                Image<Bgr, Byte> frame = null;
                bool reading = true;
                
                for (int count=1; reading; count++)
                {
                    if(count%framesToSkip != 0)
                        _capture.QuerySmallFrame().ToImage<Bgr,byte>(); // added here
                    else
                    { 
                        frame = _capture.QueryFrame().ToImage<Bgr, byte>(); // added here
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
