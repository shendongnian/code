	using (IAmazonEC2 client = new AmazonEC2Client())
	{
		string instanceId = "i-abcd1234";
		DescribeInstanceStatusResponse response = client.DescribeInstanceStatus(
            new DescribeInstanceStatusRequest
		    {
		    	InstanceIds = new List<string> { instanceId }
		    });
		InstanceStatus status = response?.InstanceStatuses.FirstOrDefault(
            x => x.InstanceId == instanceId
        );
		if (status != null)
		{
			// Perform your checks on InstanceStatus here
		}
	}
