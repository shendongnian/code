     public ActionResult Action(){
         try{
             using(AmazonS3Client client = 
                  new AmazonS3Client(accessKeyID, secretAccessKey)){
                var bucketName = 
                     ConfigurationManager.AppSettings["bucketName"]
                    .ToString() + DownloadPath;
                GetPreSignedUrlRequest request1 = 
                   new GetPreSignedUrlRequest(){
                      BucketName = bucketName,
                      Key = originalName,
                      Expires = DateTime.Now.AddMinutes(5)
                   };
    
                string url = client.GetPreSignedURL(request1);
                return Redirect(url);
             }
         }
         catch (Exception)
         {
             failure = "File download failed. Please try after some time.";   
         }              
     }
