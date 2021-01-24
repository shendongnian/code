    public class Draw : MonoBehaviour
    {
        public GameObject Brush;
    
        private bool _isDraging = false;
        //we are going to keep track of the location where we last placed an object.
        private Vector3 _lastPlacedObjectLocation;
    
        private Vector3 _get2dMousePosition()
        {
             Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
             newPos.z = 0;
             return newPos;
        }
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _isDraging = true;
            }
    
            if (Input.GetMouseButtonUp(0))
            {
                _isDraging = false;
                //keep 'old' mouse position up to date, so we do not draw in between dragging the mouse and releasing it. 
                _lastPlacedObjectLocation = _get2dMousePosition();
                return;
            }
    
            if (_isDraging)
            {
                Vector3 currentMousePosition = _get2dMousePosition();
                //now, we find how far the mouse has moved since the last step.
                Vector3 distanceTravelled = _lastPlacedObjectLocation - currentMousePosition;                
                //since we know the starting and ending point, all we have to do now is add the prefab instances, neatly spaced over the travelled distance.
               Vector3 stepDistance = distanceTravelled / spacing;
               
               //then, we interpolate between the start and end vector
               //you could make this a lot faster by determining how often your object fits in this space, but i'd like to leave you a little bit of a challenge, so i'm abusing the magnitude of the stepDistance ;)
               for(float i =0; i < stepDistance.magnitude; i+=0.1f)
               {
                  float progress = i / stepDistance.magnitude;
                  Vector3 placementPosition = Vector3.Lerp(_lastPlacedObjectLocation, currentMousePosition, progress);
                  placePrefab(placementPosition);
               }
                 
               
               //and then we update the last-placed-object location
               _lastPlacedObjectLocation = _get2dMousePosition();
            }
        }
        void placePrefab(Vector3 location)
        {
                //I have added 'Physics.OverlapBox' so that the prefab doesn't overlap with the previous prefab
                var collide = Physics.OverlapBox(location, new Vector3(0, 0, 0));
    
                if (!collide.Any())
                {
                    Debug.Log("Draw: " + location);
                    Instantiate(Brush, location, Quaternion.identity);
                }
        }
    }
