        Capture captureFrame = new Capture(Filename);
        Mat frame = new Mat();
        Mat frame_copy = new Mat();
        //Capture Image from file
        private void GetVideoFrames(String Filename)
        {
            try
            {
                captureFrame = new Capture(Filename);
                captureFrame.ImageGrabbed += ShowFrame;
                captureFrame.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //Show in ImageBox
        private void ShowFrame(object sender, EventArgs e)
        {
            captureFrame.Retrieve(frame);
            frame_copy = frame;
            imageBox1.Image = frame_copy ;
        }
