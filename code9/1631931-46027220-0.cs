    Vector3 TargetPosition;
    float speed = 1f;
    void Start()
    {
        TargetPosition = transform.position;
    }    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            TargetPosition += Vector3ToMove;
        }
        transform.position = Vector3.Lerp(transform.position, TargetPosition, speed * Time.deltaTime);
    }
 
