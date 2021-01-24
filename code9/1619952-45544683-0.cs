     void FixedUpdate () {
         // apply force the instant button is pressed. That is only once
        if (Input.GetKeyDown(KeyCode.Space) && myRB.velocity.y == 0)
        {
            myRB.AddForce(Vector3.up * 20,ForceMode2D.Impulse);
            timeHeld = 1;
    
        }
         // keep subtracting from mass while its held
        if (Input.GetKey(KeyCode.Space))
        {
            
            timeHeld += Time.deltaTime;
            myRB.mass = myRB.mass - timeHeld/10;
    
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            myRB.mass = 1;
    
        }
    }
