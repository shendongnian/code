	public partial class Form2 : Form
	{
		public Form2()
		{
			InitializeComponent();
		}
		private void Form2_Load(object sender, EventArgs e)
		{
		}
		List<Read> rList = new List<Read>();
		public void DoReadFiles(string[] fileNames)
		{
			try
			{
				rList.Clear();
				foreach (String file in fileNames) //if ((myStream = ff.OpenFile()) != null)
				{
					Read r = new Read(file);
					rList.Add(r);
				}
			}
			catch (Exception err)
			{
				//Inform the user if we can't read the file
				MessageBox.Show(err.Message);
			}
		}
		public void DoPlot(int indX = 0, int indY = 1)
		{
			Plot.Draw(chart, rList, indX, indY);
		}
		public void SavePic(string outputFile)
		{
			bool isPng = outputFile.EndsWith(".png", StringComparison.OrdinalIgnoreCase);
			chart.SaveImage(outputFile, isPng ? ChartImageFormat.Png : ChartImageFormat.Jpeg);
		}
		void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog ff = new OpenFileDialog();
			ff.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); //"C:\\";
			ff.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
			ff.Multiselect = true;
			ff.FilterIndex = 1;
			ff.RestoreDirectory = true;
			if (ff.ShowDialog() == DialogResult.OK)
			{
				try
				{
					DoReadFiles(ff.FileNames);
					//Populate the ComboBoxes
					if (rList.Count > 0)
					{
						string[] header = rList[0].header; //header of first file
						xBox.DataSource = header;
						yBox.DataSource = header.Clone(); //without Clone the 2 comboboxes link together!
					}
					if (yBox.Items.Count > 1) yBox.SelectedIndex = 1; //select second item
				}
				catch (Exception err)
				{
					//Inform the user if we can't read the file
					MessageBox.Show(err.Message);
				}
			}
		}
		private void button1_Click(object sender, EventArgs e)
		{
			DoPlot(xBox.SelectedIndex, yBox.SelectedIndex);
		}
	} //end class Form2
