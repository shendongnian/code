    public List<GameObject> l1 = new List<GameObject>();
    public List<GameObject> l2;
    
    void Start()
    {
        l2 = new List<GameObject>(l1.Count);
    }
