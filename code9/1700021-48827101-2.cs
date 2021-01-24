	private void Button_Click(object sender, RoutedEventArgs e)
	{
		var worker = new BackgroundWorker { WorkerSupportsCancellation = true };
		worker.DoWork += delegate (object sender1, DoWorkEventArgs e1)
		{
			Dispatcher.Invoke(
								 new Action(() =>{testCtl.Visibility = Visibility.Visible;}),
								 System.Windows.Threading.DispatcherPriority.Normal);
			Task.Delay(3000).Wait();
		};
		worker.RunWorkerCompleted += delegate (object s, RunWorkerCompletedEventArgs args)
		{
			testCtl.Visibility = Visibility.Collapsed;
		};
		worker.RunWorkerAsync();
	}
