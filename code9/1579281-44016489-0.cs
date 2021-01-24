    public partial class Form1 : Form
	{
		Task _task;
		CancellationTokenSource _token;
		
		public Form1()
		{
			InitializeComponent();
		}
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			_token = new CancellationTokenSource();
			_task = Task.Factory.StartNew(() => DoWork(), _token.Token);			
		}
		protected override void OnClosing(CancelEventArgs e)
		{
			_token.Cancel();
			Application.DoEvents();
			_task.Wait();
			base.OnClosing(e);
		}
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				_task.Dispose();
				_token.Dispose();
				components.Dispose();
			}
			base.Dispose(disposing);
		}
		private void SetTime()
		{
			var dt = DateTime.Now;
			label1.Text = $"{dt.Hour}:{dt.Minute}:{dt.Second}";
		}
		private void DoWork()
		{
			while (!_token.IsCancellationRequested)
			{
				if (InvokeRequired)
					Invoke(new MethodInvoker(SetTime));
			}
		}
	}
