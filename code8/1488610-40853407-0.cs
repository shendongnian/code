    void FixedUpdate ()
    {
        Debug.Log ("dead is " + dead);
        Collider[] hitColliders = = Physics.OverlapSphere (frontCheck.position, radius, whatIsWall);
    
        if (hitColliders.length != 0) {
            Debug.Log ("Player died!");
    
    
            Invoke ("Reset", 1);
        }
    }
