    [FunctionName("Function1")]
    public static void Run([TimerTrigger("*/10 * * * * *")]TimerInfo myTimer,TraceWriter log)
    {
        TokenCloudCredentials tokenCredential = new TokenCloudCredentials("{subscriptionId}", GetAuthorizationToken());
        HDInsightManagementClient _hdiManagementClient = new HDInsightManagementClient(tokenCredential);
        var results = _hdiManagementClient.Clusters.List();
        foreach (var name in results.Clusters)
        {
            Console.WriteLine("Cluster Name: " + name.Name);
            Console.WriteLine("\t Cluster type: " + name.Properties.ClusterDefinition.ClusterType);
            Console.WriteLine("\t Cluster location: " + name.Location);
            Console.WriteLine("\t Cluster version: " + name.Properties.ClusterVersion);
        }
    }
