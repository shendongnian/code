    protected ReactiveProperty<GameObject[]> spawnedObjects;
    public virtual void spawnNewObject(int index)
    {
        if (spawnedObjects.Value[index] != null)
        {
            GameObject old = spawnedObjects.Value[index];
            GameObject newSpawn = Instantiate(spawnObject, transform.position + offset, Quaternion.identity, transform);
            spawnedObjects.Value[index] = newSpawn;
            Destroy(old);
        }
    }
    public virtual void setupSpawner()
    {
        for (int i = 0; i < spawnedObjects.Value.Length; i++)
        {
            int j = i;
            spawnedObjects
                .ObserveEveryValueChanged(spawns => spawns.Value[j].activeSelf)
                .Where(active => active == false)
                .Throttle(System.TimeSpan.FromSeconds(Random.Range(timeFromTo.x, timeFromTo.y)))
                .Subscribe(_ =>
                {
                    spawnNewObject(j);
                });
        }
    }
