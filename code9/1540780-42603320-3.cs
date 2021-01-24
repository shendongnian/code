    using UnityEngine;
    using UnityEngine.UI;
    
    public class ChangeButtonSprite : MonoBehaviour {
    
    	public Sprite TexA,TexB;
    
    	void Start(){
    		GetComponent<Image>().sprite = TexA;
    	}
    
    	public void ChangeSprite(Image image){
    		if (image.sprite == TexA) {
    			image.sprite = TexB;
    			return;
    		}
    		image.sprite = TexA;
    	}
    }
