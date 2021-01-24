    public override bool OnOptionsItemSelected(IMenuItem item)
	{
		switch (item.ItemId)
		{
			case 99:
				DoSomething();
				return true;
			default:
				return false;
		}
	}
