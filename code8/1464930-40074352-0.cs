    float[] fingerIdTimer = new float[5] { 0f, 0f, 0f, 0f, 0f }; //5 fingers max
    bool[] fingerIdValid = new bool[5] { true, true, true, true, true }; //One determine invalid, must be rest in TouchPhase.Ended
    const float timeOut = 0.5f; //Anything more than 0 and less than timeOut value is tap
    void Update()
    {
        //Loop over all finger touching the screen
        for (int i = 0; i < Input.touchCount; i++)
        {
            //Will only increment if finger is valid
            if (fingerIdValid[i])
            {
                fingerIdTimer[i] += Time.deltaTime;
            }
            //If we reach the time out value and finger is still valid reset the finger id
            if (fingerIdTimer[i] > timeOut && fingerIdValid[i])
            {
                fingerIdTimer[i] = 0f; //Reset Held Time
                fingerIdValid[i] = false; //Invalid
                OnTapFailed(i, fingerIdTimer[i]);
            }
            //After touch is released, Anything more than 0 and less than timerOut value is tap
            if (Input.GetTouch(i).phase == TouchPhase.Ended)
            {
                if (fingerIdTimer[i] > 0 && fingerIdTimer[i] < timeOut)
                {
                    OnTapSuccess(i, fingerIdTimer[i]);
                }
                fingerIdTimer[i] = 0f; //Reset Held Time when released
                fingerIdValid[i] = true; //Reset Invalid when released
            }
        }
    }
    int count = 0;
    //Tap was successful
    void OnTapSuccess(int fingerId, float heldTime)
    {
        count++; //Increment the tap count
        Debug.Log("Tapped Count: " + count + "\r\n"
            + "Finger ID: " + fingerId + "\r\n"
            + "Held Time: " + heldTime);
        //scoreText.text = "Score: " + count.ToString();
        //GameObject.Find("Pride").GetComponent<Animator>().SetTrigger("Click");
    }
    //Tap failed (Time out Occured)
    void OnTapFailed(int fingerId, float heldTime)
    {
        Debug.Log("Tap Failed: " + fingerId);
    }
