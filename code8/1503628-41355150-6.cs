	private void button1_Click(object sender, EventArgs e)
	{
		System.Diagnostics.Process process = new System.Diagnostics.Process();
		process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
		process.StartInfo.FileName = "cmd.exe";
		process.StartInfo.Arguments = "/C ipconfig";
		process.StartInfo.UseShellExecute = false;
		process.StartInfo.RedirectStandardOutput = true;
		process.StartInfo.RedirectStandardInput = true;
		process.Start();
		string q = "";
		while(!process.HasExited)
		{
			q += process.StandardOutput.ReadToEnd();
		}
		label1.text = q;
		MessageBox.Show(q);
	} 
