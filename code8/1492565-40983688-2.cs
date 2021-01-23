    public class UIStoreView
    {
    	public static UIStoreView Instance()
    	{
    		SceneManager.LoadScene("UIStoreView", LoadSceneMode.Additive);
    		return GameObject.Find("UIStoreView");
    	}
    }
