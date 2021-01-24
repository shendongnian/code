    System.Windows.Forms.Timer proTimer = new System.Windows.Forms.Timer();
    private void Form1_Load(object sender, EventArgs e)
    {
        proTimer.Interval = 1000;
        progressBar1.Minimum = 0;
        progressBar1.Maximum = 100;
        progressBar1.Value = 0;
        proTimer.Tick += new EventHandler(proTimer_Tick);
    }
    private void button1_Click(object sender, EventArgs e)
    {
        proTimer.Enabled = true;
        proTimer.Start();
    }
    
    // Timer event
    void proTimer_Tick(object sender, EventArgs e)
    {
         progressBar1.Value += ProgressPercentage;
         label1.Text = String.Format("Process Complete {0}%",progressBar1.Value);        
         if (progressBar1.Value == 100)
         {
            proTimer.Stop();
            proTimer.Enbled = false;
         }
    }
