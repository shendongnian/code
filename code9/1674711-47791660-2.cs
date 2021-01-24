    //The GameObject with the pivot point to move
    public GameObject pointToRotate;
    //The Pivot point to move the GameObject around
    public Transform pivotPoint;
    
    //The angle to Move the pivot point
    public Vector3 angle = new Vector3(0f, 180f, 0f);
    
    //The duration for the rotation to occur
    public float rotDuration = 5f;
    
    void Start()
    {
        StartCoroutine(rotateObject(pointToRotate, pivotPoint.position, angle, rotDuration));
    }
