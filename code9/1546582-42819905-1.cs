    LineDrawer lineDrawer;
    
    void Start()
    {
        lineDrawer = new LineDrawer();
    }
    
    void Update()
    {
        lineDrawer.DrawLineInGameView(Vector3.zero, new Vector3(0, 40, 0f), Color.blue);
    }
