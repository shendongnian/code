    public void Looted ()
    {
        if (!pay && kicked) {
    
            pay = true;
            Instantiate (coinPrefab, coinSpawn.position, coinSpawn.rotation);
            kicked = false;
            pay = false;
            for (int i = 1; i <= 3; i++)
            {    
                Debug.Log ("$$$$$$$$$");
            }
        }
    }
