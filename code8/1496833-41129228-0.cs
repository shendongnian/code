	private int _LRL = 0;
	private int lowestSpec = Int32.MaxValue;
	public string LRL
	{
		get{return _LRL.ToString();}
		set
		{
				_LRL = Utilities.ConvertSafe.ToInt32(value);
			if(_LRL < lowestSpec)
			{
				lowestSpec = _LRL;
			}
		}
	}
