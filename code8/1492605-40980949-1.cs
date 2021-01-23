	var form = new Window();
	var tb = new TextBox();
	form.Content = tb;
	form.Show();
	var str = "alk;lfkdsfj;slfhjs;idjhf;lksdjf;klsdjf;'lkjds;lfksd";
	Task.Run(() =>
	{
		foreach (var c in str.ToCharArray())
		{
			Thread.Sleep(100);
			form.Dispatcher.Invoke(() =>
			{
				tb.Text += c;
			});
		}
	});
