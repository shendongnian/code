    float touchTimer=0f;
    float shakeTime = 2f;
    float moveAwayLimit = 1f;
    float moveBackLimit = .5f;
    bool awayReached = false;
    Vector2 startingPos;
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                startingPos = touch.position;
                touchTimer = 0;
                awayReached = false;
            }
            if (Vector2.Distance(touch.position, startingPos) > moveAwayLimit && touchTimer < shakeTime && !awayReached)
            {
                awayReached = true;
            }
            else if (Vector2.Distance(touch.position, startingPos) < moveBackLimit && touchTimer < shakeTime && awayReached)
            {
                Shake();
            }
            touchTimer += Time.deltaTime;
        }
    }
