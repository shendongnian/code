        static  void  ExecuteAsync(Customer customer)
        {
            using (Stream s1 = File.OpenRead(@"D:\toekn.txt"))
            {
            var storageAccount = CloudStorageAccount.Parse("connectionstring");
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("mycontainer");
            container.CreateIfNotExists();
            var permission = container.GetPermissions();
 
            CloudBlockBlob blob = container.GetBlockBlobReference("aaaa.txt");
 
            blob.UploadFromStream(s1);
            string  filepath = blob.Uri.AbsoluteUri;
            var credentials = new NetworkCredential("username", "password");
             var myMessage = new SendGridMessage();
            string address = "aaaaa@gmail.com";
            // Add the message properties.
            myMessage.From = new MailAddress("bbbbbb@hotmail.com", "Example User");
            myMessage.Subject = "Sending with SendGrid is Fun";
            myMessage.Text = "and easy to do anywhere, even with C#";
           // myMessage.AddAttachment(s1, "11.txt");
            myMessage.AddAttachment(filepath);
            myMessage.AddTo(address);
            myMessage.Subject = "Document";
            var transportWeb = new Web(credentials);
             transportWeb.DeliverAsync(myMessage).Wait();
            }         
        }
