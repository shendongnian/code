    var allObjects = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[]; // this will grab all GameObjects from the current scene!
    foreach(GameObejct obj in allObjects) {
        if(new Regex(@"^Button(?'number'\d{1,2})").IsMatch(obj.Tag)) {
            obj.SetActive(true);
            Debug.Log("done");
        }
    }
