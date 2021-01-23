    /*
    ISingleFingerHandler - handles strict single-finger down-up-drag
    
    Put this daemon ON TO the game object, with a consumer of the service.
    
    (Note - there are many, many philosophical decisions to make when
    implementing touch concepts; just some issues include what happens
    when other fingers touch, can you "swap out" etc. Note that, for
    example, Apple vs. Android have slightly different takes on this.
    If you wanted to implement slightly different "philosophy" you'd
    do that in this script.)
    */
    
    
    public interface ISingleFingerHandler
    	{
    	void OnSingleFingerDown (Vector2 position);
    	void OnSingleFingerUp (Vector2 position);
    	void OnSingleFingerDrag (Vector2 delta);
    	}
    
    /* note, Unity chooses to have "one interface for each action"
    however here we are dealing with a consistent paradigm ("dragging")
    which has three parts; I feel it's better to have one interface
    forcing the consumer to have the three calls (no problem if empty) */
    
    
    using UnityEngine;
    using System.Collections;
    using UnityEngine.EventSystems;
    
    public class SingleFingerInputModule:MonoBehaviour,
    				IPointerDownHandler,IPointerUpHandler,IDragHandler
    
    	{
    	private ISingleFingerHandler needsUs = null;
    	// of course that would be a List,
    	// just one shown for simplicity in this example code
    	
    	private int currentSingleFinger = -1;
    	private int kountFingersDown = 0;
    	
    	void Awake()
    		{
    		needsUs = GetComponent(typeof(ISingleFingerHandler)) as ISingleFingerHandler;
    		// of course, you may prefer this to search the whole scene,
    		// just this gameobject shown here for simplicity
    		// alternately it's a very good approach to have consumers register
    		// for it. to do so just add a register function to the interface.
    		}
    	
    	public void OnPointerDown(PointerEventData data)
    		{
    		kountFingersDown = kountFingersDown + 1;
    		
    		if (currentSingleFinger == -1 && kountFingersDown == 1)
    			{
    			currentSingleFinger = data.pointerId;
    			if (needsUs != null) needsUs.OnSingleFingerDown(data.position);
    			}
    		}
    	
    	public void OnPointerUp (PointerEventData data)
    		{
    		kountFingersDown = kountFingersDown - 1;
    		
    		if ( currentSingleFinger == data.pointerId )
    			{
    			currentSingleFinger = -1;
    			if (needsUs != null) needsUs.OnSingleFingerUp(data.position);
    			}
    		}
    	
    	public void OnDrag (PointerEventData data)
    		{
    		if ( currentSingleFinger == data.pointerId && kountFingersDown == 1 )
    			{
    			if (needsUs != null) needsUs.OnSingleFingerDrag(data.delta);
    			}
    		}
    	
    	}
