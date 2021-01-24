    public new bool BaseBoolNullable
	{
		get { return base.BaseBoolNullable ?? false; }
		set { base.BaseBoolNullable = value; }
	}
	public new int? BaseInt
	{
		get { return base.BaseInt; }
		set { base.BaseInt = value ?? 0; }
	}
