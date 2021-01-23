    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //reset countdown when click
            tim = COUNTDOWN_MAX;
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
