    [SerializedField]            // The SerializedField property makes it show up in the inspector, even though it is private
    private Ball ballPrefab;     // Attention: Type "Ball"
    public void IsHit()          // Method to execute upon rocket collision
    {
        if(ball.size != BallSizes.Smallest)
        {
            Ball leftBall = Instantiate(ballPrefab).  // Notice that, when you assign you prefab as Type "Ball", you directly get the Ball-Component as the return value.
            leftball.direction = -1;
            leftball.size = (BallSizes)(size + 1);    // Add one to size, to get get the next enum value, which is the next smaller size.
        
            Ball rightBall = ....                     // Do same stuff for the right ball
        }
        Destroy(this.gameObject);
    }
