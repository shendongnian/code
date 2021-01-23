        static void UnderstandStorageException()
        {
            var cred = new StorageCredentials(accountName, accountKey);
            var account = new CloudStorageAccount(cred, true);
            var client = account.CreateCloudBlobClient();
            var container = client.GetContainerReference("container");
            var blockBlob = container.GetBlockBlobReference("something.txt");
            try
            {
                blockBlob.UploadFromFile(@"D:\test.txt");
                blockBlob.AcquireLease(TimeSpan.FromSeconds(10), Guid.NewGuid().ToString());
                blockBlob.Delete();
            }
            catch (StorageException excep)
            {
                var requestInformation = excep.RequestInformation;
                Console.WriteLine(requestInformation.HttpStatusCode);
                Console.WriteLine(requestInformation.HttpStatusMessage);
                Console.WriteLine(requestInformation.ExtendedErrorInformation.ErrorCode);
                Console.WriteLine(requestInformation.ExtendedErrorInformation.ErrorMessage);
            }
        }
