    public bool inAir = false;
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Terrain")
            inAir = true;
    }
    
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Terrain")
            inAir = false;
    }
