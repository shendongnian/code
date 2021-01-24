	public void OnDateChanged(DatePicker view, int year, int monthOfYear, int dayOfMonth)
	{
		switch (view.Id)
		{
			case Resource.Id.datepicker_one:
				Log.Debug("SO", $"DatePicker One Value: {view.DateTime}");
				break;
			case Resource.Id.datepicker_two:
				Log.Debug("SO", $"DatePicker Two Value: {view.DateTime}");
				break;
		}
	}
