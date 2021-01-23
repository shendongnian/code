    public interface IMessageBox
    {
    	void Show(String message);
    }
    
    public class SUT
    {
    	public SUT(IMessageBox messageBox)
    	{	
    		this._messageBox = messageBox;
    	}
    	
    	public void Test()
    	{
    		this._messageBox.Show("TEST);
    	}
    }
