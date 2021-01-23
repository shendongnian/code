    float[] playerLives = new float[5]; 
    void functionCalledVeryOften()
    {
        for (int i = 0; i < playerLives.Length; i++)
        {
            playerLives[i] = UnityEngine.Random.Range(0f,5f);
        }
    }
