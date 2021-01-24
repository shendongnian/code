	private void ReleaseObject(object obj)
	{
		try {
			int intRel = 0;
			do {
				intRel = System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
			} while (intRel > 0);
			
		} catch (Exception ex) {
			
			obj = null;
		} finally {
			GC.Collect();
		}
	}
