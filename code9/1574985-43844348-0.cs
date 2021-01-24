    using UnityEngine;
    using UnityEngine.UI;
    
    public class ImageTest : MonoBehaviour {
    	public Canvas canvas;
    	public Sprite sprite;
    	public float width = 10;
    	public float height = 10;
    
    	private void Start () {
    		GameObject newObject = new GameObject("ObjectName");
    		RectTransform rectTransform = newObject.AddComponent<RectTransform>();
    		rectTransform.sizeDelta = new Vector2(width, height);
    		Image image = newObject.AddComponent<Image>();
    		image.sprite = sprite;
    		newObject.transform.SetParent(canvas.transform, false);
    	}
    };
