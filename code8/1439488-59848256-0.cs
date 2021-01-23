	    AmazonS3Client client = new AmazonS3Client();
	    ListObjectsRequest listRequest = new ListObjectsRequest
	    {
		    BucketName = "your-bucket-name",
		    Prefix = "example/path"
	    };
	    ListObjectsResponse listResponse;
	    do
	    {
		    listResponse = client.ListObjects(listRequest);
		    foreach (S3Object obj in listResponse.S3Objects)
		    {
			    Console.WriteLine(obj.Key);
			    Console.WriteLine(" Size - " + obj.Size);
		    }
		    listRequest.Marker = listResponse.NextMarker;
	    } while (listResponse.IsTruncated);
