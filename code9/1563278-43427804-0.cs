	private List<PictureBox> PBs = new List<PictureBox>();
	private void getbtn_Click(object sender, EventArgs e)  // To generate Images
	{
		if (cmbDocType.SelectedIndex > 0)
		{
			foreach(PictureBox pb in PBs)
			{
				pb.Dispose();
			}
			PBs.Clear();
			if (con.State != ConnectionState.Open)
				con.Open();
			string directory = System.IO.Directory.GetDirectoryRoot(System.IO.Directory.GetCurrentDirectory().ToString());
			string FileNamePath = directory + "MembersDocuments\\" + GlobalValues.Member_ID + "\\" + cmbDocType.Text;
			string[] list = Directory.GetFiles(FileNamePath);
			if (list.Length > 0)
			{
				label1.Text = "";
				PictureBox PB;
				int y = 0;
				for (int index = 0; index < list.Length; index++)
				{
					PB = new PictureBox();
					if (x % 3 == 0)
					{
						y = y + 150; // 3 images per rows, first image will be at (20,150)
						x = 0;
					}
					PB.Location = new Point(x * 230 + 20, y);
					PB.Size = new Size(200, 150);
					x++;
					PB.Size = new Size(200, 100);
					PB.Image = Image.FromFile(list[index]);
					PB.SizeMode = PictureBoxSizeMode.StretchImage;
					PB.Click += new EventHandler(picturebox_Click);
					PBs.Add(PB);
					this.Controls.Add(PB)
					cmbDocType_SelectedIndexChanged(PB, e);
				}
			}
			else
			{
				label1.Text = "No Images to display";
				label1.ForeColor = Color.Red;
			}
			con.Close();
		}
		else
		{
			MessageBox.Show("Please select the Document Type");
		}
	}
