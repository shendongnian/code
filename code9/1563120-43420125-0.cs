    using UnityEngine;
    
    public class AnyMethodClass : MonoBehaviour 
    {
    	public delegate void EventListener();
    	public event EventListener MyEvent;
    	public System.Action MyAction;
    	public UnityEngine.Events.UnityEvent MyUnityEvent;
    }
