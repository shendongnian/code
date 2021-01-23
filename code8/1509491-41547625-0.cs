    public static class DestroyedObjects 
    { 
        List<GameObject> objs = new List<GameObject>();
        public void Add(GameObject obj) 
        {
            if(!objs.Contains(obj))
                objs.Add(obj); 
        } 
    }
