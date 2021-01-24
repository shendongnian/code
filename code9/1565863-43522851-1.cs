    public partial class RequestInfo : Form
	{
		private Action<string, string> _sendValues = null;
		
		public RequestInfo(Action<string, string> retrieveValues)
		{
			InitializeComponent();
			_sendValues = retrieveValues;
		}
		
		private void fileBrowseButton_Click(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
				filePath.Text = openFileDialog.FileName;
		}
		
		private void folderBrowseButton_Click(object sender, EventArgs e)
		{
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
				folderPath.Text = folderBrowserDialog.SelectedPath;
		}
		
		private void okButton_Click(object sender, EventArgs e)
		{
			_sendValues(filePath.Text, folderPath.Text);
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
		
		private void cancelButton_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
