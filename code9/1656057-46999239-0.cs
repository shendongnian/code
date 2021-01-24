     //the object to move
    public Transform objectToMove;
     void Update()
     {
         Vector3 mouse = Input.mousePosition;
         Ray castPoint = Camera.main.ScreenPointToRay(mouse);
         RaycastHit hit;
         if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
         {
             objectToMove.transform.position = hit.point;
         }
     }
