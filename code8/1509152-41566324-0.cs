    bool touched = false;
    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (!touched && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo))
                {
                    if (hitInfo.GetComponentInChildren<*YOUR_CUBE_CONTROL_CLASS_NAME*>() == this)
                    {
                        touched = true;
                    }
                }
            }
            else if (touched && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                // Get movement of the finger since last frame
                Vector3 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                // Move object across XY plane
                transform.Translate(touchDeltaPosition.x * speed, 0, 0);
                Vector3 boundaryVector = transform.position;   
                boundaryVector.x = Mathf.Clamp (boundaryVector.x, -5.5f, -2.8f);
                transform.position = boundaryVector;
            }
        }
        else
        {
            touched  = false;
        }
    }
