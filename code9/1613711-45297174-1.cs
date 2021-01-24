    private void Start()
        {
            allObjects = new List<GameObject>();
            foreach(Transform child in transform)
            {
                allObjects.Add(child.gameObject)
            }
        }
