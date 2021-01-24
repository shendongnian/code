    private DateTime nextAllowedPowerUpTime = DateTime.MinValue;
    void FixedUpdate()
    {
        if (Input.GetKey("q") && DateTime.Now >= nextAllowedPowerUpTime)
        {
            rb.AddForce(0, 0, 500f * Time.deltaTime);
            // Set the next allowed power-up time to the current time plus two seconds
            nextAllowedPowerUpTime = DateTime.Now.AddSeconds(2);
        }
        else
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        }
    }
