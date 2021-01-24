    public GameObject lineprefab;
    private GameObject linehandler;
    private Vector3 mousepos;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousepos = Input.mousePosition;
            mousepos.z = 10;
    
            mousepos = Camera.main.ScreenToWorldPoint(mousepos);
            linehandler = Instantiate(lineprefab, mousepos, Quaternion.identity) as GameObject;
        }
    }
