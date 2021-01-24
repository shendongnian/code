    public GameObject[] arrows;
    public float interval = 5;
    private List<GameObject> myObjects = new List<GameObject>();
    // Use this for initialization
    void Start()
    {
        InvokeRepeating("SpawnArrow", 0f, interval);
    }
    void SpawnArrow()
    {
        //Check if there's something in the list
        if (myObjects.Count > 0)
        {
            //Destroy the last object in the list.
            Destroy(myObjects.Last());
            //Remove it from the list.
            myObjects.RemoveAt(myObjects.Count - 1);
        }
        GameObject prefab = arrows[UnityEngine.Random.Range(0, arrows.Length)];
        GameObject clone = Instantiate(prefab, new Vector3(0.02F, 2.18F, -1), Quaternion.identity);
        //Add the object to the list
        myObjects.Add(clone);
    }
