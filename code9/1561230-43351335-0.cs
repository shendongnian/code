    public GameObject[] arrows;
    public float interval = 5;
    
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
            //yield return delay;
    		return prefab; //This GameObject Array has the arrows in it, possibly (IDK Unity here) as GameObject.arrows[x]
    
        }
    }
