	[NotifyPropertyChangedInvocator]
	protected override void RaisePropertyChanged([CallerMemberName]string property = "")
	{
		base.RaisePropertyChanged(property);
	}
