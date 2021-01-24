    bool isObjectInCollision = false;
    
    void EnterCollision()
    {
        // do something
        isObjectInCollision = true;
    }
    void LeaveCollision()
    {
        // do something
        isObjectInCollision = false;
    }
    
    void SetWalkMode()
    {
        if (isObjectInCollision)
           return;
        anim.Play("SkitsWalk", -1, 0f);
    }
