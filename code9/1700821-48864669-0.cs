    using UnityEngine;
    
    public class RotateKnob : MonoBehaviour {
    	public float m_Speed;
    
    	void Update() {
    		if (Input.GetKey(KeyCode.RightArrow)) {
    			transform.Rotate(Vector3.up, Time.deltaTime * m_Speed, Space.Self);
    		}
    
    		if (Input.GetKey(KeyCode.LeftArrow)) {
    			transform.Rotate(Vector3.down, Time.deltaTime * m_Speed, Space.Self);
    		}
    
    		var angle = Vector3.SignedAngle(transform.right, transform.parent.right, transform.up);
    		Debug.Log(angle);
    	}
    }
