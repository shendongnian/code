    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //reset cooldown when click
            tim = 0;
        }
        else
        {
            //start countdown when not click
            tim -= Time.deltaTime;
            if (tim < 0)
            {
                tim = 0;
            }
        }
        //show timer
        int t = Mathf.FloorToInt(tim);
        timer.text = "timer" + t.ToString();
    }
