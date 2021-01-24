     public void Push(GameObject go) {
            if (changedObjects == null)
            { 
               changedObjects = new List<GameObject>();
            }
            if (go != null) {
                changedObjects.Add(go);
            }
     }
