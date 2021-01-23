    /*
    IPinchHandler - strict two sequential finger pinch Handling
    
    Put this daemon ON TO the game object, with a consumer of the service.
    
    (Note, as always, the "philosophy" of a glass gesture is up to you.
    There are many, many subtle questions; eg should extra fingers block,
    can you 'swap primary' etc etc etc - program it as you wish.)
    */
    
    
    public interface IPinchHandler
    	{
    	void OnPinchStart ();
    	void OnPinchEnd ();
    	void OnPinchZoom (float gapDelta);
    	}
    
    /* note, Unity chooses to have "one interface for each action"
    however here we are dealing with a consistent paradigm ("pinching")
    which has three parts; I feel it's better to have one interface
    forcing the consumer to have the three calls (no problem if empty) */
    
    
    using UnityEngine;
    using System.Collections;
    using UnityEngine.EventSystems;
    public class PinchInputModule:MonoBehaviour,
    				IPointerDownHandler,IPointerUpHandler,IDragHandler
    
    	{
    	private IPinchHandler needsUs = null;
    	// of course that would be a List,
    	// just one shown for simplicity in this example code
    	
    	private int currentFirstFinger = -1;
    	private int currentSecondFinger = -1;
    	private int kountFingersDown = 0;
    	private bool pinching = false;
    	
    	private Vector2 positionFirst = Vector2.zero;
    	private Vector2 positionSecond = Vector2.zero;
    	private float previousDistance = 0f;
    	private float delta = 0f;
    	
    	void Awake()
    		{
    		needsUs = GetComponent(typeof(IPinchHandler)) as IPinchHandler;
    		// of course, this could search the whole scene,
    		// just this gameobject shown here for simplicity
    		}
    	
    	public void OnPointerDown(PointerEventData data)
    		{
    		kountFingersDown = kountFingersDown + 1;
    		
    		if (currentFirstFinger == -1 && kountFingersDown == 1)
    			{
    			// first finger must be a pure first finger and that's that
    			
    			currentFirstFinger = data.pointerId;
    			positionFirst = data.position;
    			
    			return;
    			}
    		
    		if (currentFirstFinger != -1 && currentSecondFinger == -1 && kountFingersDown == 2)
    			{
    			// second finger must be a pure second finger and that's that
    			
    			currentSecondFinger = data.pointerId;
    			positionSecond = data.position;
    			
    			FigureDelta();
    			
    			pinching = true;
    			if (needsUs != null) needsUs.OnPinchStart();
    			return;
    			}
    		
    		}
    	
    	public void OnPointerUp (PointerEventData data)
    		{
    		kountFingersDown = kountFingersDown - 1;
    		
    		if ( currentFirstFinger == data.pointerId )
    			{
    			currentFirstFinger = -1;
    			
    			if (pinching)
    				{
    				pinching = false;
    				if (needsUs != null) needsUs.OnPinchEnd();
    				}
    			}
    		
    		if ( currentSecondFinger == data.pointerId )
    			{
    			currentSecondFinger = -1;
    			
    			if (pinching)
    				{
    				pinching = false;
    				if (needsUs != null) needsUs.OnPinchEnd();
    				}
    			}
    		
    		}
    	
    	public void OnDrag (PointerEventData data)
    		{
    		
    		if ( currentFirstFinger == data.pointerId )
    			{
    			positionFirst = data.position;
    			FigureDelta();
    			}
    		
    		if ( currentSecondFinger == data.pointerId )
    			{
    			positionSecond = data.position;
    			FigureDelta();
    			}
    		
    		if (pinching)
    			{
    			if ( data.pointerId == currentFirstFinger || data.pointerId == currentSecondFinger )
    				{
    				if (kountFingersDown==2)
    					{
    					if (needsUs != null) needsUs.OnPinchZoom(delta);
    					}
    				return;
    				}
    			}
    		}
    	
    	private void FigureDelta()
    		{
    		float newDistance = Vector2.Distance(positionFirst, positionSecond);
    		delta = newDistance - previousDistance;
    		previousDistance = newDistance;
    		}
    	
    	}
