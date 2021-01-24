    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0) && counter > DelayTime && reloading == false)                                                                   
        {
            // ...
        }
    
        // Start reloading if not already reloading and either R is pressed or clip is empty
        if (!reloading && (Input.GetKey(KeyCode.R) || currentClip <= 0))
        {
            reloading = true;
            GetComponent<AudioSource>().Play();
        }
    
        //Start of reloading
        if (reloading)
        {
            if (totalAmmo > 1)
            {
                reloadCounter += Time.deltaTime;
                if (reloadCounter > reloadTime)
                {
                    missingAmmo = clipSize - currentClip;
                    if (totalAmmo >= missingAmmo)
                    {
                        totalAmmo += currentClip;
                        totalAmmo += -clipSize;
                        currentClip = clipSize;
                    }
                    else
                    {
                        currentClip += totalAmmo;
                        totalAmmo = 0;
                    }
                    reloading = false;
                    reloadCounter = 0;
                    //End of reloading 
                }
            }
        }
        counter += Time.deltaTime;
    }
