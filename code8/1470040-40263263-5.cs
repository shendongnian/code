    void functionCalledVeryOften()
    {
        float[] playerLives = new float[5]; //This is bad because it allocates memory each time it is called
        for (int i = 0; i < playerLives.Length; i++)
        {
            playerLives[i] = UnityEngine.Random.Range(0f,5f);
        }
    }
