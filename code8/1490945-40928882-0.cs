    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            circularMove();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!jumping)
                StartCoroutine(jumpPlayer());
        }
    }
