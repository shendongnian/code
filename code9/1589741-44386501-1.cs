    // Drag & Drop the prefab of the button you will instantiate
    public GameObject buttonPrefab ;
    
    public void MakeButton(string direction)
    {
        // Instantiate (clone) the prefab    
        GameObject button = (GameObject) Instantiate( buttonPrefab ) ;
    
        var panel = GameObject.Find("CommandPanel");
        button.transform.position = panel.transform.position;
        button.GetComponent<RectTransform>().SetParent(panel.transform);
        button.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left,0,10);
        button.layer = 5;
    
    }
