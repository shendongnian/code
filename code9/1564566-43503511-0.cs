            var firstNic = vmResult.NetworkProfile.NetworkInterfaces.First();
            var nicNameParts = firstNic.Id.Split('/');
            string networkIntefaceName = nicNameParts.Last();
            using (var client = new NetworkManagementClient(credential))
            {
                client.SubscriptionId = subscriptionId;
                string publicNicId = string.Empty;
                //Query ALL Networkinterfaces in the client, and find the one with the matching NIC-name
                var nic = client.NetworkInterfaces.ListAll().FirstOrDefault(x => x.Name == networkIntefaceName);
                if (nic != null)
                {
                    //If we find that, we can now use that to find the ID of the PublicIPAddress for said NIC
                    publicNicId = nic.IpConfigurations[0].PublicIPAddress.Id;
                    //...And when we have that, we can now query all public IP addresses for that specific public Nic ID
                    var publicIp = client.PublicIPAddresses.ListAll().FirstOrDefault(x => x.Id == publicNicId);
                    if (publicIp != null)
                    {
                        vmInfo.PublicIP = publicIp.IpAddress;
                        Console.WriteLine("  public ip: " + publicIp.IpAddress);
                    }
                    else
                    {
                        Console.WriteLine("  public ip: unknown");
                    }
                }
            }
