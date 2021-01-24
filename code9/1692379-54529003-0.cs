    public static void Initialize(bool isEditor = false)
    {
        if (isEditor)
        {
            FirebaseApp firebaseApp = FirebaseApp.Create(
                FirebaseApp.DefaultInstance.Options, 
                "FIREBASE_EDITOR");
            firebaseApp.SetEditorDatabaseUrl("https://project.firebaseio.com/");
            FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
            {
                if (task.Result == DependencyStatus.Available)
                {
                    database = FirebaseDatabase.GetInstance(firebaseApp).RootReference;
                    storage = FirebaseStorage.GetInstance(firebaseApp).RootReference;
                    auth = FirebaseAuth.GetAuth(firebaseApp);
                }
                else
                {
                    Debug.LogError(
                        "Could not resolve all Firebase dependencies: " + task.Result);
                }
            });
        }
        else
        {
            FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://project.firebaseio.com/");
            database = FirebaseDatabase.DefaultInstance.RootReference;
            storage = FirebaseStorage.DefaultInstance.RootReference;
            auth = FirebaseAuth.DefaultInstance;
        }
        IsInitialized = true;
    }
