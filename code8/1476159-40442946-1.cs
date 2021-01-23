	public partial class MainForm
	{	
		private double _progress;
		public double Progress
		{
			get { return _progress; }
			set
			{
				_progress = value;
                 
                // If not in the UI thread -> wrap the update in an Invoke() call:
				if (this.InvokeRequired)
				{
					this.Invoke(new Action(() => progressBar1.Value = (int) _progress), new object[] { });
                    return;
				}
                // Else update directly
                progressBar1.Value = (int) value;
			}
		}
		private readonly DownloadManager _dm;
		public MainForm()
		{
			InitializeComponent();
			_dm = new DownloadManager();
            // Bind _db.Progress <-> this.Progress
			DataBindings.Add("Progress", _dm, "Progress", true, DataSourceUpdateMode.OnPropertyChanged);
		}
