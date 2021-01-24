    //needs: using System.Threading.Tasks;
	ival1 = new Interval();
	ival1.setInterval(async delegate{
		//webBrowser1.ScriptErrorsSuppressed = false;
		//webBrowser1.Navigate(targetUrl, false);
		MessageBox.Show(
			"MessageBox 1",
			"Hello from 1",
			MessageBoxButtons.OK,
			MessageBoxIcon.Warning
		);
		await Task.Delay(5000);
		MessageBox.Show(
			"MessageBox 2",
			"Hello from 2",
			MessageBoxButtons.OK,
			MessageBoxIcon.Warning
		);
	}, 10000);
    
