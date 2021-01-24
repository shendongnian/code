    List<GameObject> steps = new List<GameObject>();
    void Awake() {
        GameObject parentObject = GameObject.Find("Steps");
        for(int i = 0; i < parentObject.transform.childCount; i++) {
            steps.Add(parentObject.transform.GetChild(i));
        }
    }
