	namespace WindowsFormsApplication3
	{
		public partial class Form1 : Form
		{
			Stopwatch StopWatch_Summary = new Stopwatch();
			BackgroundWorker xBackgroundWorker = new BackgroundWorker();
			Label xLabel = new Label();
			public Form1()
			{
				InitializeComponent();
				xBackgroundWorker.WorkerReportsProgress = true;
				xBackgroundWorker.DoWork += xbackgroundWorker_DoWork;
				xBackgroundWorker.ProgressChanged += xbackgroundWorker_ProgressChanged;
				xLabel.Text = "XXXXXXXXXXXXX";
				StartHeavyComputation();
			}
			private void xbackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
			{
				StopWatch_Summary.Start();
				xBackgroundWorker.ReportProgress(0);
				
				for(int i=1;i<=MyX;i++)
				{
					xBackgroundWorker.ReportProgress(i);	
					//Heavy Computation that takes 38seconds to compute
				}
				
				StopWatch_Summary.Stop();
			}
			
			private void xbackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
			{
				TimeSpan timeSpan = StopWatch_Summary.Elapsed;
				xLabel.Text = String.Format("Time : {0:00}:{1:00} sec", timeSpan.Minutes, timeSpan.Seconds);
			}
			
			private void StartHeavyComputation()
			{
				xBackgroundWorker.RunWorkerAsync();       
			}
		}
	}
