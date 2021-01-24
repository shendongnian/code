     void Update()
        {
            double speed = 0.0;
            speed = speed * 0.95;
            if (Input.GetKeyDown("Up"))
            {
                speed += 2;
                transform.Translate(speed, 0, 0);
            }
            if (Input.GetKeyDown("Down"))
            {
                speed += 2;
                transform.Translate(-speed, 0, 0);
            }
            if (Input.GetKeyDown("Right"))
            {
                speed += 2;
                transform.Translate(0, 0, speed);
            }
            if (Input.GetKeyDown("Left"))
            {
                speed += 2;
                transform.Translate(0, 0, -speed);
            }
        }
    }
