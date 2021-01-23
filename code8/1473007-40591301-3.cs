    public class FingerMove:MonoBehaviour, ISingleFingerHandler, IPinchHandler
    	{
    	public void OnSingleFingerDown(Vector2 position) {}
    	public void OnSingleFingerUp (Vector2 position) {}
    	public void OnSingleFingerDrag (Vector2 delta)
    		{
    		_processSwipe(delta);
    		}
    	
    	public void OnPinchStart () {}
    	public void OnPinchEnd () {}
    	public void OnPinchZoom (float delta)
    		{
    		_processPinch(delta);
    		}
    	
    	private void _processSwipe(Vector2 screenTravel)
    		{
    		.. handle drag (perhaps move LR/UD)
    		}
    	
    	private void _processPinch(float delta)
    		{
    		.. handle zooming (perhaps move camera in-and-out)
    		}
    	}
