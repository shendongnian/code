    Transform cameraTransform; 
    void Start()
    {
        cameraTransform = Camera.main.gameObject.transform;
    }
    public void Update()
    {
        cameraTransform.Translate(7, 0, 0);
    }
