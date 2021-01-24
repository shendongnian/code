    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            controller.Play("walking_inPlace");
            transform.Translate(0, 0, speed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            controller.Play("walking_inPlace");
            transform.Translate(0, 0, -speed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            controller.Play("walking_inPlace");
            transform.Translate(speed, 0, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            controller.Play("walking_inPlace");
            transform.Translate(-speed, 0, 0);
        }
        else 
        {
             controller.Play("breathing_idle");
        }
    }
