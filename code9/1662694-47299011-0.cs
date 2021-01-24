    public class Crasher : MonoBehaviour
    {
    	public bool isCrash = false;
    	//The crash in seconds
    	public float crashDuration = 5;
    	
    	void Update ()
    	{
    		if (isCrash)
    		{
    			//Freeze the applicaion for amount of milliSeconds
    			System.Threading.Thread.Sleep(crashDuration * 1000);
    		}
    	}
    }
