    public static class UT
    {
    	public static Process StartProcess(this ProcessStartInfo psi, bool useShellExecute = true)
    	{
    		psi.UseShellExecute = useShellExecute;
    		return Process.Start(psi);
    	}
    }
