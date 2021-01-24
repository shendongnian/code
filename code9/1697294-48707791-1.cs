    //The two positions to generate point between
    Vector3 positionA = new Vector3(0, 0, 0);
    Vector3 positionB = new Vector3(254, 210, 50);
    
    //The number of points to generate
    const int pointsCount = 10;
    //Where to store those number of points
    private Vector3[] pointsResult;
    
    void Start()
    {
        pointsResult = new Vector3[pointsCount];
        generatePoints(positionA, positionB, pointsResult, pointsCount);
    }
