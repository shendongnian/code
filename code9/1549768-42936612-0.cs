    void landingPod()
    {
        int spawnIndex = Random.Range(0, spawns.Length);
        while(spawns[spawnIndex] == null)
        {
            spawnIndex = Random.Range(0, spawns.Length);
        }
        if (spawns[spawnIndex] != null)
        {
            Instantiate(podPrefab, spawns[spawnIndex].position, spawns[spawnIndex].rotation);
        }
        else {
            if (spawns[spawnIndex] == null)
                return;
        }
    }
