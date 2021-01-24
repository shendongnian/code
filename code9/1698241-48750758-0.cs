	public string get_CtxString(string strItemType)
	{
		try
		{
			return myContext.ContextString(strItemType);
		}
		catch (Exception ex)
		{
			return "";
		}
	}
	public void set_CtxString(string strItemType, string value)
	{
		try
		{
			myContext.ContextString(strItemType) = value;
		}
		catch (Exception ex)
		{
		}
	}
