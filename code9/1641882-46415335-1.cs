    void FixedUpdate () {
        // Calculates the time until the enemy may decide to change its movement
        moveTime += Time.deltaTime;
        timeTilNextDecision = idleTime - moveTime;
    
        if (timeTilNextDecision < 0)
        {
            MakeMovementDecision();
        }
    }
    
    /// <summary>
    /// Generates the decision for which type of movement the enemy will perform
    /// </summary>
    private void MakeMovementDecision ()
    {
        // Chooses a value upon which the movement decision will be based
        decisionValue = Random.Range(0, 3);
    
        switch (decisionValue)
        {
            // Keeps the enemy standing still
            case 0:
                Idle();
                break;
    
            // Moves the enemy to the right
            case 1:
                MoveRight();
                break;
    
            // Moves the enemy to the left
            case 2:
                MoveLeft();
                break;
        }
    }
    
    /// <summary>
    /// Causes the enemy to stand still with idle animations 
    /// </summary>
    private void Idle ()
    {
        
        // Sets the idle stance duration
        idleTime = Random.Range(5.0f, 10.0f);
        // Sets the movement bool to false to play the idle animations
        isMoving = false;
    
        // Stops the enemy's movement
        enemyRigidbody.velocity = Vector2.zero;
    
        // Checks if the enemy should make a decision on its next movement
        
    
    }
    
    private void MoveRight()
    {
        moveTime = Random.Range(2.0f, 5.01f);
        isMoving = true;
        directionToMove = Vector2.right;
        transform.Translate(directionToMove * (movementSpeed * Time.deltaTime));
    }
    
    private void MoveLeft()
    {
        moveTime = Random.Range(2.0f, 5.01f);
        isMoving = true;
        directionToMove = Vector2.left;
        transform.Translate(directionToMove * (movementSpeed * Time.deltaTime));
    }
