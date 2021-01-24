    public BallPool ballPool; // assign from the inspector
    
    void Start() // or whatever other method
    {
        var ball = ballPool.GetObjectFromPool();
        ball.Setting();
    }
