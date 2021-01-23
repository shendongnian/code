    void Awake()
    {
        GameObject obj = GameObject.Find("PlayerHealth");
        if (obj == null)
        {
            Debug.Log("Failed to find PlayerHealth GameObject");
            return;
        }
    
        playerController = obj.GetComponent<PlayerController>();
        if (playerController == null)
        {
            Debug.Log("No PlayerController is attached to obj");
        }
    }
