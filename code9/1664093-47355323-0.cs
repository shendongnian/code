    void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<IOpenable>() != null)
        {
    
        }
    
        else if (collider.GetComponent<IDestroyable>() != null)
        {
    
        }
    }
