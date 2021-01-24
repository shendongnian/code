    void OnCollisionEnter(Collision collision)
    {
        Action action;
    
        if (objToAction.TryGetValue(collision.gameObject, out action))
        {
            //Execute the approprite code
            action();
        }
    }
