    public Transform playerPos;
    public Transform rigthCamBoundary;
    public Transform levelEnd;
    
    Vector3 destination;
    Vector3 velocity = Vector3.zero;
    float yPos;
    
    private void Start()
    {
        destination = Vector3.ClampMagnitude(levelEnd.position, 22.8f);
        destination = new Vector3(destination.x, destination.y, 13.5f);
    
        //Get the default camera y pos
        yPos = transform.position.y;
    }
    
    private void FixedUpdate()
    {
        if (Vector3.Distance(playerPos.position, rigthCamBoundary.position) < 13.7f)
        {
            Vector3 tempPos = Vector3.SmoothDamp(transform.position, levelEnd.position, ref velocity, .14f, 8.5f);
    
            //Apply the default camera y pos
            tempPos.y = yPos;
            transform.position = tempPos;
        }
    }
