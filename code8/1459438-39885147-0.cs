    GameObject[] spheres;
    public float moveSpeed = 50;
    void Start()
    {
        spheres = GameObject.FindGameObjectsWithTag("MySphere");
    }
    private void Update()
    {
        UpdateSpheres();
        MoveShips();
    }
    private void MoveShips()
    {
        foreach (Transform child in spheres[0].transform)
        {
            child.transform.position += Vector3.forward * Time.deltaTime * moveSpeed;
        }
    }
