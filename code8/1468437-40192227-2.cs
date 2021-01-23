    private List<GameObject> instantiated;
    ...
    void SpawnObjects()
    {
        // (re-)initialize as empty list
        instantiated = new List<GameObject>();
        foreach(GameObject spawnPosition in spawnPositions)
        {
            int selection = Random.Range(0, spawnObjects.Count);
            instantiated.Add((GameObject)Instantiate(spawnObjects[selection], spawnPosition.transform.position, spawnPosition.transform.rotation));
        }
    }
