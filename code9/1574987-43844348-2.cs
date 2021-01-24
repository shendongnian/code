    using UnityEngine;
    
    public class TextureTest : MonoBehaviour {
    	public Texture texture;
    
    	private void Start () {
    		GameObject newObject = GameObject.CreatePrimitive(PrimitiveType.Quad);
    		MeshRenderer meshRenderer = newObject.GetComponent<MeshRenderer>();
    		meshRenderer.material.mainTexture = texture;
    	}
    }
