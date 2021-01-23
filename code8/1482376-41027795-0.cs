    // Use this for initialization
    void Start () {
    
        MyScript myScriptInstance = FindObjectOfType<MyScript> ();
    
        GameObject go = DefaultControls.CreateButton (new DefaultControls.Resources());
        var btn = go.GetComponent<Button> ();
    
        btn.onClick.AddListener (myScriptInstance.TestMethod);
    }
