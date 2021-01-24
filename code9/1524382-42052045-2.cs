        if (waveTimer >= waveWait)
        {
          IncrementWave();
          waveTimer = 0f;
          haveToSpawn = true; //new variable
        }
        if (haveToSpawn && spawnTimer >= spawnWait)
        {
            for (int i = 0; i < zombieCount; i++)
            {
                [..] //spawn each zonbie
            }
            spawnTimer = 0f; //reset spawn delay
            haveToSpawn = false; //disallow spawing
        }
