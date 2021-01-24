        foreach (FilterInfo CaptureDevice in webcams)
        {
            // Enable the cameras display
            ViewLabelflowLayoutPanel.Controls[index].Visible = true;
            ImageLabelflowLayoutPanel.Controls[index].Visible = true;
            ViewflowLayoutPanel.Controls[index].Visible = true;
            ImageflowLayoutPanel.Controls[index].Visible = true;
            CameracomboBox.Items.Add(CaptureDevice.Name);
            try
            {
                Cameras[index] = new VideoCaptureDevice(webcams[index].MonikerString);
                Cameras[index].NewFrame += new NewFrameEventHandler(cam_NewFrame);
                Cameras[index].Start();
            }//endtry
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }//endcatch
        }//endforeach
        CameracomboBox.SelectedIndex = 0;
        index++;
     public void cam_NewFrame(object sender, EventArgs e){
         VideoCaptureDevice cam = sender as VideoCaptureDevice;
         //do what you need to do with cam here.
     }
