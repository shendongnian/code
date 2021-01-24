    // value indicating what was the position before change
    Vector3 previousPosition;
    
    void Update ()
    {
        // get user input as a vector
        Vector3 horizontal = Vector3.right * Input.GetAxis("horizontal");
        Vector3 vertical = Vector3.forward * Input.GetAxis("vertical");
    
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float speedModifier = isRunning ? runSpeed : walkSpeed;
        // add these inputs together
        Vector3 currentVelocity = (horizontal + vertical);
        
        // check if player is in mid air
        if (IsInAir)
        {
            // if it is, get the previous and current positions
            // add calculate the distance between frames
            // and normalize it to get the movement direction
            Vector3 currentPosition = transfor.position;
            Vector3 direction = (currentPosition - previousPosition).Normalize();
            // apply movement direction to the "currentVelocity"
            currentVelocity = direction * speedModifier * Time.deltaTime;
        }
        else
        {
            // user is not in mid air so you can just calculate
            // the position change
            currentVelocity = currentVelocity.Normalize() * speedModifier * Time.deltaTime;
            if ( currentVelocity != Vector3.zero )
            {
                animator.SetBool("walking", !isRunning);
                animator.SetBool("running", isRunning);
            }
        }
    
        // current position ( before changes )
        // should be copied to a previous position
        // to calculate it in the next frame update
        previousPosition = currentPosition;
        // do the translation
        transform.Translate(currentVelocity);
    }
