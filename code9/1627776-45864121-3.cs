    void Update () 
    {
        Vector2 ChrP = transform.position;
        if (ChrP == new Vector2(-3.03f, 3.02f))
        {
            if ( Mathf.Abs(Input.GetAxisRaw("Right")) > 0.0f ) 
            {
                transform.position = new Vector2(-1.36f, 3.02f);
            } 
            if ( Mathf.Abs(Input.GetAxisRaw("Down")) > 0.0f ) 
            {
                transform.position = new Vector2(-3.03f, 1.401f);
            }
        }
    }
