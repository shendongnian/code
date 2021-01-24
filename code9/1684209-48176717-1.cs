    bool move;
    float t;
    Update()
    {
        if () // insert condition to begin movement
        {
            move = true;
            t = 0; // reset timer
            startPos = transform.position; // store current position for lerp
            finalPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (move)
            MovePlayer();
    }
    void MovePlayer()
    {
        t += Time.deltaTime / 3f; // 3 is seconds to take to move from start to end
        transform.position = Vector2.Lerp(startPos, finalPosition, t);
        if (t > 3)
        {
            t = 0; // reset timer
            move = false; // exit function
        }
    }
