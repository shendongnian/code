    public class PlaceObject : MonoBehaviour {
    	
      float objDist = 1.0f;
    
      void Update() {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began ) {
          Vector3 touchPos = Input.GetTouch (0).position;
          touchPos.z = objDist;
          Vector3 objPos = Camera.main.ScreenToWorldPoint (touchPos);
    
          GameObject myObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
          myObj.transform.position = objPos;
          myObj.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
      }
    }
