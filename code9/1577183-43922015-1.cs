    public float xMoveThreshold = 1000.0f;
    public float yMoveThreshold = 1000.0f;
    //Y limit
    public float yMaxLimit = 45.0f;
    public float yMinLimit = -45.0f;
    float yRotCounter = 0.0f;
    //X limit
    public float xMaxLimit = 45.0f;
    public float xMinLimit = -45.0f;
    float xRotCounter = 0.0f;
    Transform player;
    void Start()
    {
        player = Camera.main.transform;
    }
    // Update is called once per frame
    void Update()
    {
        //Get X value and limit it
        xRotCounter += Input.GetAxis("Mouse X") * xMoveThreshold * Time.deltaTime;
        xRotCounter = Mathf.Clamp(xRotCounter, xMinLimit, xMaxLimit);
        //Get Y value and limit it
        yRotCounter += Input.GetAxis("Mouse Y") * yMoveThreshold * Time.deltaTime;
        yRotCounter = Mathf.Clamp(yRotCounter, yMinLimit, yMaxLimit);
        //xRotCounter = xRotCounter % 360;//Optional
        player.localEulerAngles = new Vector3(-yRotCounter, xRotCounter, 0);
    }
