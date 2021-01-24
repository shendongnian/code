    public Timer Timer;
    void FixedUpdate()
    {
        if (transform.position.y < threshold)
        {
            Timer.StopTimer();
            transform.position = new Vector3(403, 266, 337);
        }
    }
