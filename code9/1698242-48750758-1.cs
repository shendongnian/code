	public void SetCtxString(string strItemType, string value)
	{
		try
		{
			myContext.ContextString(strItemType) = value;
		}
		catch (Exception ex)
		{
		}
	}
