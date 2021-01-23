	static bool IsSFHosted()
	{
		try
		{
			FabricRuntime.GetNodeContext();
			return true;
		}
		catch (FabricException sfEx) when (sfEx.HResult == -2147017661 || sfEx.HResult == -2147017536 || sfEx.InnerException?.HResult == -2147017536)
		{
			return false;
		}
	}
