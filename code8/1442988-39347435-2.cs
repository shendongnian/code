    public GameObject testCubePrefab;
    public Transform dst1;
    public Transform dst2;
    void Start()
    {
        int myDistances = 2;
        Vector3[] distancesResult = new Vector3[myDistances];
        posToChunkDistances(dst1.position, dst2.position, distancesResult, myDistances, true, 5f);
        for (int i = 0; i < distancesResult.Length; i++)
        {
            Instantiate(testCubePrefab, distancesResult[i], Quaternion.identity);
        }
    }
