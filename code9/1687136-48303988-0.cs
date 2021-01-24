    public List<GameObject> shapes;
    public List<GameObject> spawnedShape;
    public int nextShape;
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject go = Resources.Load("shape" + i) as GameObject;
            shapes.Add(go);
        }
        int nextShape = getRandom(0, 4);
    }
    
    void Update()
    {
        if (Input.GetButton("Fire1")) {
            spawnShape();
        }
    }
    public int getRandom(int min, int max)
    {
        System.Random random = new System.Random();
        return random.Next(min, max);
    }
    void spawnShape()
    {
        //creates instance of shape
        GameObject go = Instantiate(shapes[nextShape]);
        //creates and assigns random x, y coordinate
        int x = getRandom(0, 500);
        int y = getRandom(0, 500);
        go.transform.position = new Vector3(x, y, 0);
        spawnedShape.Add(go);
        //gets colour of next shape
        nextShape = getRandom(0, 4);
    }
