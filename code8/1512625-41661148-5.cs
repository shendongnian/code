		List<Read> rrList = new List<Read>();
		void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog ff = new OpenFileDialog();
			Read rr;
			ff.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); //"C:\\";
			ff.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
			ff.Multiselect = true;
			ff.FilterIndex = 1;
			ff.RestoreDirectory = true;
			if (ff.ShowDialog() == DialogResult.OK)
			{
				try
				{
					rrList.Clear();
					foreach (String file in ff.FileNames) //if ((myStream = ff.OpenFile()) != null)
					{
						rr = new Read(file);
						rrList.Add(rr); 
					}
					//Populate the ComboBoxes
					if (rrList.Count > 0)
					{
						string[] header = rrList[0].header; //header of first file
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
			Plot.Draw(rrList, xBox, yBox, chart);
		}
