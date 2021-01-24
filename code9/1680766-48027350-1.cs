    private InstanceState getInstanceState(string instanceId)
    {
        using (IAmazonEC2 client = new AmazonEC2Client())
        {
            var statusResponse = client.DescribeInstanceStatus(new DescribeInstanceStatusRequest()
            {
                InstanceIds = new List<string>() { instanceId }
            });
    
            return statusResponse?.InstanceStatuses?.FirstOrDefault(
                x => x.InstanceId == instanceId).InstanceState;
        }
    }
