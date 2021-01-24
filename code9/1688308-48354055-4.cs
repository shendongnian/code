		private void wc_DownloadFileComplete(object sender, AsyncCompletedEventArgs e)
		{
			progressBar1.PerformStep();
			if( e.Error != null )
			{
				string msg = String.Format("Error downloading MSSV {0}\r\n\r\n{1}",progressBar1.Value,e.Error.Message);
				MessageBox.Show(msg);
			}
			if( progressBar1.Maximum == progressBar1.Value )
			{
				MessageBox.Show("All downloads completed.");
				WebClient wc = sender as WebClient;
				if( wc != null )
					wc.Dispose();
			}
		}
		private void button1_Click(object sender, EventArgs e)
		{
			int mssv = Convert.ToInt32(textBox2.Text);
			int amount = Convert.ToInt32(textBox3.Text);
			progressBar1.Value = 0;
			progressBar1.Maximum = amount;
			WebClient wc = new WebClient();
			wc.DownloadFileCompleted += new AsyncCompletedEventHandler(wc_DownloadFileComplete);
			for(int i = 0; i < amount; i++, mssv++)
			{
				Uri url = new Uri(String.Format("abc.com/GetImage.aspx?MSSV={0}",mssv));
				string path = String.Format("{0}.jpg",mssv);
				wc.DownloadFileAsync(url,path);
			}
		}
