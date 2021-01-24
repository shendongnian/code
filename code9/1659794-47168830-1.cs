    private async void MyMethod()
    {
         checkDeviceAuthorizationStatus(); //Removed async Task stuff
         await checkPhotoLibraryAccess();
         displayButtons(); //IT WORKS
    }
