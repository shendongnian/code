    public Light gunLight; 
    public float timeBetweenBullets = 0.15f;
    void Update ()
    {
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;
        // If the Fire1 button is being press and it's time to fire...
        if(Input.GetButton ("Fire1") && timer >= timeBetweenBullets)
        {
            Shoot ();
        }
        // If the timer has exceeded the proportion of timeBetweenBullets that the effects should be displayed for...
        if(timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects ();
        }
    }
    public void DisableEffects ()
    {
        // Disable the line renderer and the light.
        gunLight.enabled = false;
    }
    
    void Shoot (){
        timer = 0f;
        // Enable the light.
        gunLight.enabled = true;
    
    }
