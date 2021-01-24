    public GameObject[] allCubes;
    
    void Awake()
    {
        allCubes = GameObject.FindGameObjectsWithTag("cube").OrderBy(go => go.name).ToArray();
    }
