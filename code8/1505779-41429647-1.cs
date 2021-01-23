        public static void Start<T>() where T : iBase, new()
        {
            var instance = new T();
    
            instance.DoWork("tst");
        }
