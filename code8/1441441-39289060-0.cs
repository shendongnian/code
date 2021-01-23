    public class SoundManager : MonoBehaviour
    {
    	void OnEnable()
    	{
    		AudioListener.volume = PlayerPrefs.GetFloat("volume",0);
    	}
    
    	public void Mute(bool vv)
    	{
    		if (vv)
    		{
    			AudioListener.volume = 0;
    		}
    		else 
    		{
    			AudioListener.volume = 1;
    		}
    		PlayerPrefs.SetFloat("volume",AudioListener.volume);
    	}
    }
