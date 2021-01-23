	private void button1_Click(object sender, EventArgs e)
	{
		System.Diagnostics.Process process = new System.Diagnostics.Process();
		System.Diagnostics.ProcessStartInfo startiNFO = new  System.Diagnostics.ProcessStartInfo();
		startiNFO.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
		startiNFO.FileName = "cmd.exe";
		startiNFO.Arguments = "/C ipconfig";
		startiNFO.UseShellExecute = false;
		process.StartInfo.RedirectStandardOutput = true;
		process.StartInfo.RedirectStandardInput = true;
		process.StartInfo = startiNFO;
		process.Start();
		string q = "";
		while ( ! process.HasExited ) 
		{
			q += process.StandardOutput.ReadToEnd();
		}
		label1.text = q;
		MessageBox.Show(q);
	} 
