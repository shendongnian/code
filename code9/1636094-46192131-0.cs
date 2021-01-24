    public class HitAll : MonoBehaviour
    {
        //Detect up to 100 Objects
        const int raycastAmount = 100;
        RaycastHit2D[] result = new RaycastHit2D[raycastAmount];
    
        void Update()
        {
            #if UNITY_IOS || UNITY_ANDROID
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                checkRaycast(Input.GetTouch(0).position);
            }
            #else
            if (Input.GetMouseButtonDown(0))
            {
                checkRaycast(Input.mousePosition);
            }
            #endif
        }
    
        void checkRaycast(Vector2 mousePos)
        {
            Vector3 origin = Camera.main.ScreenToWorldPoint(mousePos);
    
            int hitCount = Physics2D.RaycastNonAlloc(origin, Vector2.zero, result, 200);
            Debug.Log(hitCount);
    
            for (int i = 0; i < hitCount; i++)
            {
                Debug.Log("Hit: " + result[i].collider.gameObject.name);
            }
        }
    }
