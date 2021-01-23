    List<GameObject> allObjects = new List<GameObject>();
    Scene activeScene = SceneManager.GetActiveScene();
    activeScene.GetRootGameObjects( allObjects );
    foreach(GameObject obj in allObjects) {
        if(obj.Tag == "Enemy") {
            // do some magic here
        }
    }
