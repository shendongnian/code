	private void SetPing(long ping, string content, string tooltip)
	{
		try
		{
			this.Dispatcher.BeginInvoke(DispatcherPriority.Send, (Action)(() =>
			{
				this.Ping.Content = content;
				this.Ping.ToolTip = tooltip;
				this.SetDock();
			}));
			if (this.EnableColors)
			{
				this.Ping.Dispatcher.BeginInvoke(DispatcherPriority.Send, (Action)(() =>
				{
					this.Ping.Foreground = this.GetColorByPing(ping);
				}));
			}
		}
		catch (Exception ex)
		{
		}
	}
