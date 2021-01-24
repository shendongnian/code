    public GameObject[] allCubes;
    
    void Awake()
    {
        allCubes = GameObject.FindGameObjectsWithTag("cube");
        allCubes = allCubes.OrderBy(obj => obj.name, new AlphanumComparatorFast()).ToArray();
    }
