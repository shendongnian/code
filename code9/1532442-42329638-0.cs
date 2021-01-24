    public GameObject uiPanelPrefab;
    
    void Start()
    {
        //Show
        Instantiate(uiPanelPrefab);
        //Hide
        Destroy(uiPanelPrefab);
    }
