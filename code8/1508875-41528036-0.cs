    private PlayerController playerController;
    
    void Start()
    {
        playerController = transform.parent.gameObject.GetComponent<PlayerController>();
    }
    
    void Update()
    {
        if (playerController.selectedObject ==
            gameObject)
        {
            Glow();
        }
    }
