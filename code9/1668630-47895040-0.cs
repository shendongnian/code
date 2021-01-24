	string accessKeyID = "ACCESKEYID";
	string secretAccessKey = "SECRETACCESSKEY";
	using (client = Amazon.AWSClientFactory.CreateAmazonS3Client(accessKeyID, secretAccessKey))
	{
		try
		{
		
			//First, get a list of all objects in the bucket.  We need to go through them one at a time.
			ListObjectsRequest listobjectsrequest = new ListObjectsRequest();
			listobjectsrequest = new ListObjectsRequest();
			listobjectsrequest.BucketName = "mybucketname";
			ListObjectsResponse listobjectresponse = client.ListObjects(listobjectsrequest);
			// Process each item
			foreach (S3Object entry in listobjectresponse.S3Objects)
			{
				//Get the object so we can look at the headers to see if it already has a cache control header
				GetObjectRequest getobjectrequest = new GetObjectRequest
				{
					BucketName = listobjectsrequest.BucketName,
					Key = entry.Key,
				};
				
				GetObjectResponse object1 = client.GetObject(getobjectrequest);
				string cacheControl1 = object1.Headers["Cache-Control"] ?? "none";
				//If no cache control header, then COPY the object to ITSELF but add the headers that we need
				if (cacheControl1 != "none")
				{
					
					CopyObjectRequest copyobjectrequest = new CopyObjectRequest
					{
						SourceBucket = listobjectsrequest.BucketName,
						SourceKey = entry.Key,
						DestinationBucket = listobjectsrequest.BucketName,
						DestinationKey = entry.Key,
						Directive = S3MetadataDirective.REPLACE, //Required if we will overwrite headers
						CannedACL = S3CannedACL.PublicRead //Need to set to public so it can be read
					};
					
					copyobjectrequest.AddHeader("Cache-Control", "max-age=31536000,public");
					CopyObjectResponse copyobjectresponse = client.CopyObject(copyobjectrequest);
				}
											
			}
		}
		catch (AmazonS3Exception amazonS3Exception)
		{
			Console.WriteLine(amazonS3Exception.Message, amazonS3Exception.InnerException);
		}
	}
