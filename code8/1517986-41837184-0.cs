	private void button1_Click(object sender, EventArgs e)
	{
		if (listView1.SelectedItems.Count > 0)
		{
			foreach(ListViewItem lvi in listView1.SelectedItems)
			{
				if (lvi.Tag != null && lvi.Tag is string)
				{
					string fullPathFile = lvi.Tag.ToString();
					try
					{
						Process.Start(fullPathFile);
					}
					catch (Exception ex)
					{
						MessageBox.Show("FileName: " + fullPathFile + "\r\n\r\n" + ex.ToString(), "Error Opening File");
					}
				}
			}
		}
	}
