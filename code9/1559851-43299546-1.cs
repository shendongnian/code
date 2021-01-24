    public string SceneName {
        get {
            if (scene == null)
            {
                return string.Empty; //maybe or something else
            }
            Debug.Log ("Scene Name : " + scene.name);
            return scene.name;
        }
    }
