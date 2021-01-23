    private Trans MoveTo;
    private bool move;
    
    void Update()
    {
        if (move)
        {
            float passedTime = 0;
            passedTime += Time.deltaTime;
    
            transform.position = Vector3.Lerp(transform.position, MoveTo.position, passedTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, MoveTo.rotation, passedTime);
        }
    }
