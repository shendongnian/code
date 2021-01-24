    if (isSpinning)
    {
        if (speed < maxspeed)
        {
            speed += acceleration;
        }
        if (speed > maxspeed)
        {
            speed = maxspeed;
        }
    }
    else
    {
        if (speed > 0)
        {
            speed -= acceleration;
        }
        if (speed < 0)
        {
            speed = 0;
        }
    }
