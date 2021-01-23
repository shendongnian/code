        Read rr;
		List<Read> rrList = new List<Read>(); // *** new
		void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Stream myStream = null;
			OpenFileDialog ff = new OpenFileDialog();
			ff.InitialDirectory = "C:\\";
			ff.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
			ff.Multiselect = true;
			ff.FilterIndex = 1;
			ff.RestoreDirectory = true;
			if (ff.ShowDialog() == DialogResult.OK)
			{
				try
				{
					rrList.Clear(); //***
					foreach (String file in ff.FileNames) //if ((myStream = ff.OpenFile()) != null)
					{
						using (myStream = File.OpenRead(file))
						{
							rr = new Read(myStream);
                            rr.fileName = Path.GetFileName(file);  // !!! new
							string[] header = rr.get_Header();
							List<string> lX = new List<string>();
							List<string> lY = new List<string>();
							for (int i = 0; i < header.Length; i++)
							{
								lX.Add(header[i]); lY.Add(header[i]);
							}
							//Populate the ComboBoxes
							xBox.DataSource = lX;
							yBox.DataSource = lY;
							// Close the stream
							myStream.Close();
						}
						rrList.Add(rr); //***
					}
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
			Plot p = new Plot(rrList, xBox, yBox, chart); //*** use rrList instead of rr
		}
