    public GameObject lineprefab;
    private GameObject linehandler;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayCast = Camera.main.ScreenPointToRay(Input.mousePosition);
            linehandler = Instantiate(lineprefab, rayCast.GetPoint(10), Quaternion.identity) as GameObject;
        }
    }
