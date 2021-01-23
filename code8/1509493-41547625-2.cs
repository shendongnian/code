    public static class DestroyedObjects 
    { 
        static List<GameObject> objs = new List<GameObject>();
        public static void Add(GameObject obj) 
        {
            if(!objs.Contains(obj))
                objs.Add(obj); 
        } 
    }
