	bool pause = false;
	
	IObservable<EventPattern<EventArgs>> observable =
		Observable
			.FromEventPattern<EventHandler, EventArgs>(
				h => listBox1.SelectedIndexChanged += h,
				h => listBox1.SelectedIndexChanged -= h)
			.Where(ep => pause != true);
	
	IDisposable subscription =
		observable
			.Subscribe(ep => listBox1_SelectedValueChanged(ep.Sender, ep.EventArgs));
