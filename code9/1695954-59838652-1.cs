            using Google.Apis.Auth.OAuth2;
            using Google.Cloud.Storage.V1;
            
            string file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Test.csv");
            File.WriteAllText(file, "test");
    
            GoogleCredential credential = null;
            BucketConnector bucketConnector = new BucketConnector();
            credential = bucketConnector.ConnectStream();
            var storageClient = StorageClient.Create(credential);
     
            string folderPath = ConfigurationParameters.FOLDER_NAME_IN_BUCKET;
            using (FileStream file = File.OpenRead(localPath))
            {
                objectName = folderPath + Path.GetFileName(localPath);
                storage.UploadObject(bucketName, objectName, null, file);           
            }
