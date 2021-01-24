	TaskCompletionSource<string> _tcs;
	public Task<string> Readline()
	{
		_tcs = new TaskCompletionSource<string>();
       
		EventHandler handler = null;
		handler = new EventHandler((sender, args) =>
		{
            var entry = sender as Entry;
			_tcs.SetResult(entry.Text);
            entry.Text = string.Empty;
			entry.Completed -= handler;
		});
        var ctrl = inEntry;
        ctrl.Completed += handler;
        ctrl.Focus();
		return _tcs.Task;
	}
