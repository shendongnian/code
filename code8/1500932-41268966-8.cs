	public void DoSomethingWithWidgets(ICollection<Widget> widgets)
	{
		if (widgets.Count == 0)
		{
			HandleEmptyCollection();
			return;
		}
		foreach (widget in widgets)
		{
			ProcessWidget(widget);
		}
	}
