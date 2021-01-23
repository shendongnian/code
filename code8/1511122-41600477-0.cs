    public bool CanStart = false;
     
     void Start ()
     {
         StartCoroutine (StartMove());
     }
     
     void Update ()
     {
         if (CanStart == true)
         {
               //get a value between 0 and 1
                float normalizedTime = Mathf.Repeat (Time.time, PingPongTime) / PingPongTime;
                //then multiply it by the delta between start and end point, and add start point to the result
                float xPosition = normalizedTime * (MaxX - MinX) + MinX;
                //finally update position using rigidbody 
                rb.MovePosition (new Vector3 (xPosition, rb.position.y, rb.position.z))
             
         }
         
     }
     
     IEnumerator StartMove()
     {
         yield return new WaitForSeconds (5.0f);
         CanStart = true;
     }
