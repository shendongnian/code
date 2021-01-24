    void SpawnPylon(int index, Transform[] spawnPoint, float dist, string debug)
    {
        if ((int)transform.position.z % dist == 0)
        {
            //Debug.Log(debug);
            //this makes the GameObject spawn randomly
            spawnIndex = Random.Range(0, spawnPoints.Length);
            //This is instantiationg the GameObject
            GameObject go = Instantiate(pilons[index], spawnPoint[spawnIndex].position, spawnPoint[spawnIndex].rotation) as GameObject;
            go.name = string.Format("ID: {0}", index);
        }
    }
    private void SpawnMultiplePylons()
    {
        if (currPosition != (int)transform.position.z)
        {
            SpawnPylon(1, spawnPoints, spawnNormPylonDis, "Spawn1");
            SpawnPylon(0, spawnPoints, spawnCoinPylonDis, "Spawn2");
            currPosition = (int)transform.position.z;
        }
    }
