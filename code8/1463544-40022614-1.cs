    using WebCam_Capture;
    	void MainFormLoad(object sender, EventArgs e)
    {
     webcam = new WebCam();
    webcam.InitializeWebCam(ref pictureBox1);
    }
