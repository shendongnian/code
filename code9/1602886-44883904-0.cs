    void Update()
        {
            rbody = basketball.GetComponent<Rigidbody>();
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                final = Vector3.zero;
                length = 0;
                SW = false;
                Vector2 touchDeltaPosition = Input.GetTouch(0).position;
                startpos = new Vector3(touchDeltaPosition.x, 0,             touchDeltaPosition.y);
            }
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                SW = true;
            }
    
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Canceled)
            {
                SW = false;
            }
    
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)
            {
                SW = false;
            }
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                if (SW)
                {
                    Vector2 touchPosition = Input.GetTouch(0).position;
                    endpos = new Vector3(touchPosition.x, 0, touchPosition.y);
                    final = endpos - startpos;
                    length = final.magnitude;
                    rbody.AddForce(new Vector3(touchPosition.x, 0, touchPosition.y));
                }
            }
        }
