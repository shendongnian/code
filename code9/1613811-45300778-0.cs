    boo GetKeyDown()
    {
        return ...;
    }
---
    private Transform player;
    void Awake()
    {
        //Find the player object and set it
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        // Checks if you click the space bar and gets you to -1, 0, 0
        if (Input.GetKeyDown(KeyCode.Space))
              transform.position = new Vector3(-1, 0, 0);
    }
