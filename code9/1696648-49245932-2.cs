	private static void DoesBucketExist(BasicAWSCredentials credentials, RegionEndpoint regionEndpoint)
	{
		using (var client = new AmazonS3Client(credentials, regionEndpoint))
		{
			var doesS3BucketExist = AmazonS3Util.DoesS3BucketExist(client, "randombucket");
			Console.WriteLine(doesS3BucketExist);
		}
	}
