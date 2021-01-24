    private bool isReloading = false;
    
    void Update ()
    {
        if (!isReloading)
        {
            // When ammo has depleted or player forces a reload
            if (Ammo == 0 || (Input.GetButtonDown ("Reload") && Ammo < 8))
            {
                // Play sound once, signal reloading to begin, and disable shooting
                reloadfx.Play ();
                isReloading = true;
                reload.shoot = false;
            }
        }
        else
        {
            // isReloading will be the opposite of whether the reload is finished
            isReloading = !ReloadAction();
            if (!isReloading)
            {
                // Once reloading is done, enable shooting
                reload.shoot = true;
            }
        }
        text.text = Ammo + "/8";
    }
    
    // Performs reload action, then returns whether reloading is complete
    public bool ReloadAction()
    {
        //for as long as the timer is smaller then the reload time
        if (timer < reloadTime) 
        {
            timer += Time.deltaTime;
        }
        else
        {
            //after the reload reset the timer and ammo count
            Ammo = 8;
            timer = 0.0f;
            return true;
        }
        return false;
    }
