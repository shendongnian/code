    private bool collidingWithSpeed;
    private bool collidingWithPoint;
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("speed"))
        {
            collidingWithSpeed = true ;
            //do something
        }
        else if (col.CompareTag("point"))
        {
            collidingWithPoint = true ;
            //do something
        }
    
        if( collidingWithSpeed && collidingWithPoint )
        {
             // Do something when your object collided with both triggers
        }
    }
    // Don't forget to set the variables to false when your object exits the triggers!
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("speed"))
        {
            collidingWithSpeed = false;
        }
        else if (col.CompareTag("point"))
        {
            collidingWithPoint = false;
        }
    }
