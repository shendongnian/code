        using Google.Apis.Auth.OAuth2;
        using Google.Cloud.Storage.V1;
        string file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Test.csv");
        File.WriteAllText(file, "test");
        GoogleCredential credential = null;
        BucketConnector bucketConnector = new BucketConnector();
        credential = bucketConnector.ConnectStream();
        var storageClient = StorageClient.Create(credential);
        //Upload object in google bucket 
        string folderPath = ConfigurationParameters.FOLDER_NAME_IN_BUCKET;
        using (FileStream file = File.OpenRead(localPath))
        {
            objectName = folderPath + Path.GetFileName(localPath);
            storage.UploadObject(bucketName, objectName, null, file);           
        }   
     // get list of object from google bucket and specific folder   
    ListObjectsOptions listObjectsOptions = new ListObjectsOptions();
                    listObjectsOptions.Delimiter = "/";
                   foreach (var obj in storageClient.ListObjects(ConfigurationParameters.BUCKET_NAME ,ConfigurationParameters.FOLDER_NAME_IN_BUCKET , listObjectsOptions))
                    {
                        string obj_name = obj.Name;
                     }
