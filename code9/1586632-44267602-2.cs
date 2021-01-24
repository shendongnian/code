    private float nextAllowedPowerUpTime = 0;
    void FixedUpdate()
    {
        if (Input.GetKey("q") && Time.time >= nextAllowedPowerUpTime)
        {
            rb.AddForce(0, 0, 500f * Time.deltaTime);
            // Set the next allowed power-up time to the current time plus two seconds
            nextAllowedPowerUpTime = Time.time + 2;
        }
        else
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        }
    }
