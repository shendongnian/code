    public int collisions = 0;
    
    void OnCollisionEnter(Collision collision)
    {
        collisions++;
    }
    
    void OnCollisionExit(Collision collision)
    {
        collisions--;
    }
