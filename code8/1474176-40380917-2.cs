	public partial class FormNotification : Form
	{
		private Timer timer;
		public int Duration { get; private set;}
		public FormNotification(string message, int duration)
		{
			InitializeComponent();
			this.labelMessage.Text = message;
			this.Duration = duration;
			this.timer = new Timer();
			this.timer.Interval = 1000;
			this.timer.Tick += new EventHandler(timer_Tick);
		}
		void timer_Tick(object sender, EventArgs e)
		{
			if (Duration <= 0)
				this.Close();
			this.Duration--;
		}
		private void buttonHide_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		private void FormNotification_Load(object sender, EventArgs e)
		{
			this.timer.Enabled = true;
		}
	}
