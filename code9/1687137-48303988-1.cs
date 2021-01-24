    //shapes to be spawned
    public List<GameObject> shapes;
    //shapes that are in game
    public List<GameObject> spawnedShape;
    //num of next shape to be places
    public int next;
    //list of shapes that can be spawned
    public List<int> shapeCount;
    System.Random random;
    void Start()
    {
        random = new System.Random();
        for (int i = 0; i < 4; i++)
        {
            //adds shapes that can be added into shapecount list.
            for(int j = 0; j < 4; j++)
            {
                shapeCount.Add(i);
            }
            //load game objects from resources into list
            GameObject go = Resources.Load("shape" + i) as GameObject;
            shapes.Add(go);
        }
        //set next shape
        int next = setNext();
    }
    
    void Update()
    {
        if (Input.GetButton("Fire1")) {
            spawnShape();
        }
    }
    public int setNext()
    {
        if (shapeCount.Count != 0)
        {
            int num = random.Next(0, shapeCount.Count);
            return shapeCount[num];
        }
        else return -1;
    }
    void spawnShape()
    {
        if(next == -1)
        {
            Debug.Log("Out of shapes");
        }else
        {
            //creates instance of shape
            GameObject go = Instantiate(shapes[next]);
            //creates and assigns random x, y coordinate
            int x = random.Next(0, 500);
            int y = random.Next(0, 500);
            go.transform.position = new Vector3(x, y, 0);
            spawnedShape.Add(go);
        }
        //gets colour of next shape
        next = setNext();
    }
