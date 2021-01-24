    void SpawnWaves()
    {
        while (!Player.isDead && ScoreCntl.wave < 9)
        {
            if (waveTimer >= waveWait)
            {
                IncrementWave();
                for (int i = 0; i < zombieCount; i++)
                {
                    if (spawnTimer >= spawnWait)
                    {
                        [..]
                        spawnTimer = 0f;
                    }
                }
                waveTimer = 0f;
            }
        }
    }
