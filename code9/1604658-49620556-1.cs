    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if(animator.GetBool("falling") == true)
            {
                //If I am colliding with the Ground, and if falling is set to true
                //set falling to false.
                //In my Animator, I have a transition back to walking when falling = false.
                animator.SetBool("falling", false);
                falling = false;
            }
        }
    }
    
    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            //If I exit the Ground Collider, set falling to True.
            //In my animator, I have a transition that changes the animation 
            //to Falling if falling is true.
            animator.SetBool("falling", true);
            falling = true;
        }
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
            {
                 //If I collide with a wall, I want to fall backwards.
                 //In my animator controller, if ranIntoWall = true it plays a fall-
                 //backwards animation and has an exit time.
                animator.SetBool("ranIntoWall", true);
                falling = true;
                //All player movement is inside of an if(!falling){} block
            }
    }
