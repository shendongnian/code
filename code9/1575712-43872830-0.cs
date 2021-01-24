    public GameObject playerballPrefab;
    public Transform spawpoint;
    private GameObject playerballInstance;
    
    private void Update()
    {
       if(playerballInstance == null)
       {
           playerballInstance = Instantiate(playerballPrefab, spawpoint.position, spawpoint.rotation);
          // Other spawn logic / modification
       }
    
       //do stuff with playerballInstance every frame
    }
