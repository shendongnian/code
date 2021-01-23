        VideoCapture _capture;
        bool run = true;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.ShowDialog();
            tbxFileName.Text = d.FileName;
            tbxFileName.Refresh();
            _capture = new Emgu.CV.VideoCapture(d.FileName);
            _capture.ImageGrabbed += ProcessFrame;
            double fps = _capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.Fps);
            double frameCount = _capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameCount);
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
            progressBar1.Step = 1;
            int currentFrame = 1;
            while(run)
            {
                if (!_capture.Grab())
                    run = false;
                progressBar1.Value = Convert.ToInt32((++currentFrame / frameCount) * 100);
                Thread.Sleep(Convert.ToInt32(1000.0 / fps));
                Application.DoEvents();
            }
        }
        private void ProcessFrame(object sender, EventArgs arg)
        {
            Action a = () =>
            {
                UMat captured = new UMat();
                Boolean cap = _capture.Retrieve(captured);
                pictureBox1.Image = captured.Bitmap;
                pictureBox1.Refresh();
            };
            pictureBox1.Invoke(a);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            run = false;
        }
    }
