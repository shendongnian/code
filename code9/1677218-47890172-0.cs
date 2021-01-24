    int amountOfProjectiles = 8;
    if (Input.GetButtonDown("Fire1"))
        {
            for(int i = 0; i < amountOfProjectiles; i++)
            {
                ShotgunRay();
            }
        }
