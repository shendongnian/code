    void Update()
    {
        if(CheckState())
        {
            ChangeState();
        }
    }
    
    void CheckState()
    {
        switch(paddleState)
        {
            case PaddleState.Retargetting: // choose new target and reset stationary timer
                {
                    stationaryFor = 0.0f;
                    if(targets.Length >= currentTargetIdx)
                    {
                        currentTargetIdx = 0;
                    }
                    paddletarget = targets[currentTargetIdx++]; // post increment 
                    return true;
                }
    
            case PaddleState.Moving: // move paddle and check the distance to target, if distance is less than x then go to the stationary state
                {
                    paddle.position =Vector3.Lerp(paddle.position, targets[currentTargetIdx], smooth * Time.deltaTime);
                    return Vector3.Delta(paddle.position, targets[currentTargetIdx]) < 0.5f; // arbitrary distance 
                }
             
             case PaddleState.Stationary: // do not move for 3 seconds
                {
                    stationaryFor += Time.deltaTime;
                    return stationaryFor >= 3.0f;
                }
        }
    }
    
    void ChangeState()
    {
        // go to the next state
        paddleState = (int)paddleState + 1 > PaddleState.Stationary ? PaddleState.Retargeting : (PaddleState)((int)paddleState + 1);
    }
