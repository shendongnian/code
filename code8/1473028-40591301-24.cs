    public class FingerMove:MonoBehaviour, ISingleFingerHandler
    	{
    	public void OnSingleFingerDown(Vector2 position) {}
    	public void OnSingleFingerUp (Vector2 position) {}
    	public void OnSingleFingerDrag (Vector2 delta)
    		{
    		_processSwipe(delta);
    		}
    	
    	private void _processSwipe(Vector2 screenTravel)
    		{
    		.. move the camera or whatever ..
    		}
    	}
