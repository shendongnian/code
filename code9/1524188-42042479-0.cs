    void Start() {
        var button = GameObject.Find("GameObjectWithMyButton").GetComponent<Button>();
        button.onClick.AddListener(MyMethod);
    }
    void MyMethod() {
        // Do something when button is clicked.
    }
