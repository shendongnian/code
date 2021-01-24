    void Update()
    {
        float currentMoveSpeed = moveSpeed * Time.deltaTime;
        float horizontal = Input.GetAxisRaw("Horizontal");
        bool isMovingHorizontal = Mathf.Abs(horizontal) > 0.5f;
        float vertical = Input.GetAxisRaw("Vertical");
        bool isMovingVertical = Mathf.Abs(vertical) > 0.5f;
        PlayerMoving = true;
        if (isMovingVertical && isMovingHorizontal)
        {
            //moving in both directions, prioritize later
            if (wasMovingVertical)
            {
                myRigidBody.velocity = new Vector2(horizontal * currentMoveSpeed, 0);
                lastMove = new Vector2(horizontal, 0f);
            }
            else
            {
                myRigidBody.velocity = new Vector2(0, vertical * currentMoveSpeed);
                lastMove = new Vector2(0f, vertical);
            }
        }
        else if (isMovingHorizontal)
        {
            myRigidBody.velocity = new Vector2(horizontal * currentMoveSpeed, 0);
            wasMovingVertical = false;
            lastMove = new Vector2(horizontal, 0f);
        }
        else if (isMovingVertical)
        {
            myRigidBody.velocity = new Vector2(0, vertical * currentMoveSpeed);
            wasMovingVertical = true;
            lastMove = new Vector2(0f, vertical);
        }
        else
        {
            PlayerMoving = false;
            myRigidBody.velocity = Vector2.zero;
        }
    }
