    public class AsyncClient
    {
    	private Action<string> setText;
    	
    	public AsyncClient(Action<string> setText)
    	{
    		this.setText = setText;
    	}
