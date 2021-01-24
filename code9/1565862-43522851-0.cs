    public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			button1.Click += button1_Click;
		}
		
		private void button1_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Ready to submit?", "Review", MessageBoxButtons.OKCancel, 
				MessageBoxIcon.None, MessageBoxDefaultButton.Button2);
			
			if (result.Equals(DialogResult.OK))
			{
				// submit
			}
		}
	}
