	private void StartProcess()
	{
		System.Diagnostics.Process process = new System.Diagnostics.Process();
		process.StartInfo.FileName               = /* path + binary */;
		process.StartInfo.Arguments              = /* arguments */;
		process.StartInfo.WorkingDirectory       = /* working directory */;
		process.StartInfo.RedirectStandardOutput = true;
		process.StartInfo.RedirectStandardError  = true;
		process.StartInfo.UseShellExecute        = false;
		process.StartInfo.CreateNoWindow         = true;
		process.OutputDataReceived += Process_OutputDataReceived;
		process.ErrorDataReceived += Process_ErrorDataReceived;
		process.Start();
		process.BeginOutputReadLine();
		process.BeginErrorReadLine();
		process.WaitForExit();
	}
	private void Process_ErrorDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
	{
		/* e.Data will contain string with error message */
	}
	private void Process_OutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
	{
		/* e.Data will contain string with output */
	}
