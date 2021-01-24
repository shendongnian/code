    public float speed = 1.19f;
    
    void Update()
    {
        //PingPong between 0 and 1
        float time = Mathf.PingPong(Time.time * speed, 1);
        Debug.Log(time);
    }
