    public GameObject prefab;
    // ...
    if (distance > 10)
    {
        // Calculate your target position
        Vector3 pos;
        // Instantiate the wall's GO
        var wall = Instantiate(prefab, pos, Quaternion.identity) as GameObject;
    }
