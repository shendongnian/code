	public override string this[int index]
	{
		get
		{
			if (index < 0 || Length <= index)
			{
				throw new ArgumentOutOfRangeException();
			}
			using (new ProtectedPointer(this))
			{
				return GetValue(index);
			}
		}
		set
		{
			if (index < 0 || Length <= index)
			{
				throw new ArgumentOutOfRangeException();
			}
			using (new ProtectedPointer(this))
			{
				SetValue(index, value);
			}
		}
	}
