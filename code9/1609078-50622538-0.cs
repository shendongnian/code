    if (Input.GetKey(KeyCode.R))
            {
                if(bulletsMagazine!= 15)
                {   
                    if (bulletsTotal > 0)
                    {
                        asGun.clip = reload;
                        asGun.Play();
                        Reloadgun();
                    } 
                }
            }
