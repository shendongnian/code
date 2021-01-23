         var serviceModel = ServiceModelSectionGroup.GetSectionGroup(ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None));
            var endpoints = serviceModel.Client.Endpoints;
            foreach (ChannelEndpointElement e in endpoints)
            {
                if (e.Name == "HTTP_Port")
                Console.WriteLine(e.Address);
            }
            Console.ReadLine();
