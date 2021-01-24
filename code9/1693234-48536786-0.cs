      private void CreateDirectoryForPictures ()
        {
            App._dir = new File (
                Environment.GetExternalStoragePublicDirectory (
                    Environment.DirectoryPictures), "CameraAppDemo");
            if (!App._dir.Exists ())
            {
                App._dir.Mkdirs( );
            }
        }
