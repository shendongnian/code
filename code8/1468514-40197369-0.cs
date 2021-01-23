        public Image img;
        public VideoFileReader reader;
        private void button1_Click(object sender, EventArgs e)
        {
            reader = new VideoFileReader();
            reader.Open("d:\\result.avi");
            backgroundWorker1.RunWorkerAsync();
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            for (i=0;i<reader.FrameCount;i++)
            {
                img = pictureBox1.Image;
                pictureBox1.Image = reader.ReadVideoFrame();
                if (img != null) img.Dispose();
                watch.Start();
                while (watch.ElapsedMilliseconds < reader.FrameRate);
                watch.Stop();
                watch.Reset();
            }
        }
