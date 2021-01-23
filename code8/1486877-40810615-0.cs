    private static RSACryptoServiceProvider CreateRsaCypher(string containerName = DefaultContainerName)
    {
      // Create the CspParameters object and set the key container 
      // name used to store the RSA key pair.
      CspParameters cp = new CspParameters();
      cp.KeyContainerName = containerName;
      cp.Flags = CspProviderFlags.UseExistingKey | CspProviderFlags.UseMachineKeyStore;
      // Create a new instance of RSACryptoServiceProvider that accesses
      // the key container MyKeyContainerName.
      return new RSACryptoServiceProvider(cp);
    }
