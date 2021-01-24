	private System.Windows.Forms.Timer tmr = new Timer();
	private System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
	private void Form1_Load(object sender, EventArgs e)
	{
		tmr.Interval = 1000;
		tmr.Tick += Tmr_Tick;
		tmr.Start();
		sw.Start();
	}
	private void Tmr_Tick(object sender, EventArgs e)
	{
		lblSeconds.Text = ((int)sw.Elapsed.TotalSeconds).ToString();
	}
