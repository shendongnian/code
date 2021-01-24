    public List<GameObject> l1 = new List<GameObject>();
    public List<GameObject> l2;
    
    void Start()
    {
        l2 = new List<GameObject>(l1.Count);
        Debug.Log("Capacity: " + l2.Capacity);
        for (int i = 0; i < l1.Count; i++)
        {
            l2.Add(l1[i]);
        }
        Debug.Log("Count: " + l2.Count);
    }
