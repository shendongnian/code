        void Start ()
        {
            getFolderPath().Wait();
            Debug.Log("About to call CreateAsync");
            PhotoCapture.CreateAsync(false, OnPhotoCaptureCreated);
            Debug.Log("Called CreateAsync");
        }
     //Notice how now it returns Task
        async Task getFolderPath()
        {
            StorageLibrary myPictures = await Windows.Storage.StorageLibrary.GetLibraryAsync(Windows.Storage.KnownLibraryId.Pictures);
            //.....
        }
