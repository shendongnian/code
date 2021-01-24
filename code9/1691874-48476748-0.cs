    public GameObject obj;
    private Dictionary<int, GameObject> myInst = new Dicitionary<int, GameObject>();
    private void Update()
    {
        int pos = (int)Mathf.Round(transform.position.y);
        if (pos % 4 == 0 && !myInst.ContainsKey(pos)) // check if key exists
        {
            myInst[pos] = Spawn();  // add gameObject to dictionary 
        }
    }
    // return the gameObject you spawned
    public GameObject Spawn()
    {
        return Instantiate(obj, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
    }
