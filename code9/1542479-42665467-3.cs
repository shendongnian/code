    Collider[] colliders = new Collider[5];
    
    void Update()
    {
        int hitCount = Physics.OverlapSphereNonAlloc(transform.position, 3, colliders);
    
        if (hitCount > 0)
        {
            Debug.Log("Touching!");
    
            for (int i = 0; i < hitCount; i++)
            {
                Collider C = colliders[i];
    
                Debug.Log("In Foreach for: " + C.name.ToString());
                if (C.transform.CompareTag("Enemy Unit"))
                {
                    Debug.Log(C.name.ToString() + " Is an enemy");
    
                    //...
                }
            }
        }
        else
        {
            Debug.Log("Not Touching!");
        }
    }
