    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            float middle = Screen.width / 2;
            if (touch.position.x < middle)
            {
                MoveLeft();
            }
            else if (touch.position.x > middle)
            {
                MoveRight();
            }
        }
        else
        {
            StopMoving();
        }
    }
