                var amazonS3Config = new AmazonS3Config();
                amazonS3Config.RegionEndpoint = RegionEndpoint.USEast1;// use your region endpoint
                var s3Client = new AmazonS3Client("your access key", "your secret key", amazonS3Config);
                PutObjectRequest request = new PutObjectRequest();
                request.BucketName = "your bucket name";
                request.Key = "your file key name";
                request.InputStream = File.Open(@"d:\SmallData\Doc1.pdf", FileMode.OpenOrCreate);
                // please generate your own keys 
                String CustomerKey = "qsiFY0xPeBtZn55eaT6i/bFLgpkO30QKNucYMGlbnck=";
                String CustomerKeyMD5 = "RyOu+4ghh+CgGcPryIvPdw==";
    
                request.ServerSideEncryptionCustomerMethod = ServerSideEncryptionCustomerMethod.AES256;                
                request.ServerSideEncryptionCustomerProvidedKey = CustomerKey;
                request.ServerSideEncryptionCustomerProvidedKeyMD5 = CustomerKeyMD5;
                s3Client.PutObject(request); // save the file encrypted to amazonS3
