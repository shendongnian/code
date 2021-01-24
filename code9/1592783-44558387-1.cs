            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("");
            CloudAnalyticsClient c1 = storageAccount.CreateCloudAnalyticsClient();
            DateTimeOffset starttime = DateTime.Now.AddHours(-6);
            DateTimeOffset endtime = DateTime.Now;
            var r1 = c1.ListLogRecords(Microsoft.WindowsAzure.Storage.Shared.Protocol.StorageService.Blob, starttime, endtime).ToList();
            if (r1 != null)
            {
                Console.WriteLine("Start");
            }
            int i = 0;
            foreach (var item in r1)
            {
                if (item.RequestUrl.ToString() == "yourstoragebloburl")
                {
                    Console.WriteLine(string.Format("AuthenticationType : {0} , ClientRequestId : {1} , ReferrerHeader : {2} , RequestUrl : {3} , RequestStatus : {4} , HttpStatusCode : {5} , OperationType : {6}", item.AuthenticationType, item.ClientRequestId, item.ReferrerHeader, item.RequestUrl, item.RequestStatus, item.HttpStatusCode, item.OperationType));
                    Console.WriteLine("----------------------------------");
                }
                if (item.RequestUrl.ToString() == "yourstoragebloburl" && item.OperationType == "GetBlob" && item.RequestStatus == "Success")
                {
                    i++;
                }
            }
            Console.WriteLine("Get/Dowanload blob time : " + i);
            Console.WriteLine("Complete");
