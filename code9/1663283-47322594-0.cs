    using UnityEngine;
    using UnityEngine.UI;
    
    public class TrackMouse : MonoBehaviour
    {
    	public Text text;
    	//get reference to the RectTransform component
    	private RectTransform rectTransform;
    	
    	void Start ()
    	{
    		rectTransform = text.GetComponent<RectTransform>();
    		
    		//Set the anchor to Left Below Corner
    		rectTransform.anchorMin = new Vector2(0,0);
    		rectTransform.anchorMax = new Vector2(0,0);
    	}
    	
    	void Update ()
    	{
    		//update the position of the text
    		rectTransform.anchoredPosition3D = Input.mousePosition;
    		//display position info on the text
    		text.text = Input.mousePosition.ToString();
    	}
    }
