	public MyClass
	{    
		private int myNumberField;
		public int MyNumberField 
		{ 
			get	{ return myNumberField; } 
			set
			{ 
				if (value >= 1 && value <=3)
					myNumberField = value;
				else
					// throw exception?
					// set default-value (maybe 1)?
					// do nothing?
			}
		}
	}
