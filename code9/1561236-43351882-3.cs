    public GameObject[] arrows;
    public float interval = 5;
    private List<GameObject> myObjects = new List<GameObject>();
    // Use this for initialization
    void Start()
    {
        StartCoroutine(SpawnArrow());
    }
    public IEnumerator SpawnArrow()
    {
        WaitForSeconds delay = new WaitForSeconds(interval);
        while (true)
        {
            GameObject prefab = arrows[UnityEngine.Random.Range(0, arrows.Length)];
            GameObject clone = Instantiate(prefab, new Vector3(0.02F, 2.18F, -1), Quaternion.identity);
            //Add the object to the list
            myObjects.Add(clone);
            yield return delay;
        }
    }
