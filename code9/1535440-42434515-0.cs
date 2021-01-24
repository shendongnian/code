            var _registryManager = RegistryManager.CreateFromConnectionString(_connectionString);
            var devices = await _registryManager.GetDevicesAsync(100); //Here I use 100 for testing purpose. Replace this value with yours.
            foreach (var dev in devices)
            {
                if (dev.Authentication.X509Thumbprint.IsValid(false))
                {
                    var primaryThumbprint = dev.Authentication.X509Thumbprint.PrimaryThumbprint;
                    var secondaryThumbprint = dev.Authentication.X509Thumbprint.SecondaryThumbprint;
                    Console.WriteLine("primaryThumbprint:" + primaryThumbprint);
                    Console.WriteLine("SecondaryThumbprint:" + SecondaryThumbprint);
                }
            }
