    public float speed = 50;
    
    public Rigidbody2D rb1;
    
    public Rigidbody2D rb2;
    
    public void Update()
    {
        //Player one (WASD)
        movePlayer(rb1, KeyCode.A, KeyCode.D, KeyCode.W, KeyCode.S);
    
        //Player one (Arrow keys)
        movePlayer(rb2, KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.DownArrow);
    }
    
    void movePlayer(Rigidbody2D targetRg, KeyCode left, KeyCode right, KeyCode up, KeyCode down)
    {
        Vector2 hAndV = getInput(targetRg, left, right, up, down);
    
        Vector3 tempVect = new Vector3(hAndV.x, hAndV.y, 0);
        tempVect = tempVect.normalized * speed * Time.deltaTime;
    
        Vector3 newPos = targetRg.transform.position + tempVect;
        checkBoundary(targetRg, newPos);
    }
    
    Vector2 getInput(Rigidbody2D targetRg, KeyCode left, KeyCode right, KeyCode up, KeyCode down)
    {
        Vector2 input = Vector4.zero;
    
        //Horizontal
        if (Input.GetKey(left))
            input.x = -1;
        else if (Input.GetKey(right))
            input.x = 1;
        else
        {
            input.x = 0;
            targetRg.velocity = Vector3.zero;
            targetRg.angularVelocity = 0f;
        }
    
        //Vertical
        if (Input.GetKey(up))
            input.y = 1;
        else if (Input.GetKey(down))
            input.y = -1;
        else
        {
            input.y = 0;
            targetRg.velocity = Vector3.zero;
            targetRg.angularVelocity = 0f;
        }
    
        return input;
    }
    
    void checkBoundary(Rigidbody2D targetRg, Vector3 newPos)
    {
        //Convert to camera view point
        Vector3 camViewPoint = Camera.main.WorldToViewportPoint(newPos);
    
        //Apply limit
        camViewPoint.x = Mathf.Clamp(camViewPoint.x, 0.04f, 0.96f);
        camViewPoint.y = Mathf.Clamp(camViewPoint.y, 0.07f, 0.93f);
    
        //Convert to world point then apply result to the target object
        Vector3 finalPos = Camera.main.ViewportToWorldPoint(camViewPoint);
        targetRg.MovePosition(finalPos);
    }
