    using UnityEngine;
    
    public class SpriteTest : MonoBehaviour {
    	public Sprite sprite;
    
    	private void Start () {
    		GameObject newObject = new GameObject("ObjectName");
    		SpriteRenderer spriteRenderer = newObject.AddComponent<SpriteRenderer>();
    		spriteRenderer.sprite = sprite;
    	}
    }
