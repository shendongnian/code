    static void Main(string[] args)
    {
        CertificateCloudCredentials credential = new CertificateCloudCredentials("{subscriptionId}", GetStoreCertificate("{thumbprint}"));
        using (var computeClient = new ComputeManagementClient(credential))
        {
            var result = computeClient.HostedServices.GetDetailed("{your-cloudservice-name}");
            var productionDeployment=result.Deployments.Where(d => d.DeploymentSlot == DeploymentSlot.Production).FirstOrDefault();
        }
        Console.WriteLine("press any key to exit...");
        Console.ReadKey();
    }
