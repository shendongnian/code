	private void ReleaseObj(object obj)
	{
		try 
		{
			System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
		}
		catch {}
		finally 
		{
			obj = null;
		}
	}
	
