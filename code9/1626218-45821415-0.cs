        var type = typeof(LoggingManager);
        using (var host = new ServiceHost(type))
        {
            /*
             * Work-around to the conflict between global port sharing and local port sharing 
             * caused by Net.Tcp Sharing Serivces and the default port exclusivity (hogging) of Metadata Exchange binding.
             */
            var mexBinding = new CustomBinding(MetadataExchangeBindings.CreateMexTcpBinding());
            mexBinding.Elements.Find<TcpTransportBindingElement>().PortSharingEnabled = true;
            host.AddServiceEndpoint(typeof(IMetadataExchange), mexBinding, "mex");
            host.Open();
            Console.WriteLine("Service started. Press [Enter] to exit.");
            Console.ReadLine();
            host.Close();
        }
