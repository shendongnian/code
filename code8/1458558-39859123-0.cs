        private void Loop()
        {
            while (threadRunning)
            {
                BeginInvoke(new MethodInvoker(() => timeLabel.Text = DateTime.Now.ToString()));
                Thread.Sleep(100);
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            threadRunning = false;
            thread.Join();
        }
