    List<GameObject> pool = new List<GameObject>();
    
    void Start()
    {
        for (int i = 0; i < 50; i++)
        {
            GameObject tempObj = Instantiate(prefab, postion, Quaternion.identity) as GameObject;
            pool.Add(tempObj);
        }
    }
