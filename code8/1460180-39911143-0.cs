    Random r = new Random();
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            starCounter = (starCounter + 1) % 5;
            if (starCounter == 0) SpawnStar(r.Next(0, 4));
        }
    }
