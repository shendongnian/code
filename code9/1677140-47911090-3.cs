    public class MyServiceEndPoint 
    {
        public string TypeName { get; set; }
        
        public string Url { get; set; }
    	
    	public string Name { get; set; }
    }
	
    //// generates routing service configuration section, including client enoints/filterTable/backups and routing service behavior
    private void CreateRoutingConfiguration(List<MyServiceEndPoint> serviceEndpoints)
    {
         ///// group endopints by Name, each service could have multiple endpoints ( 1 main and n backup endpoints)
    	var groupedEndpoitns = (from endp in serviceEndpoints
                                        group endp by endp.Name into endpGroup
                                        select new { ServiceName = endpGroup.Key, EndPoint = endpGroup }).ToList();
    
    
    
        var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        var serviceModelSectionGroup = System.ServiceModel.Configuration.ServiceModelSectionGroup.GetSectionGroup(config);
    
        var routingSection = (RoutingSection)serviceModelSectionGroup.Sections["routing"];
        var clientsection = (ClientSection)serviceModelSectionGroup.Sections["client"];
        var bindingSection = (BindingsSection)serviceModelSectionGroup.Sections["bindings"];
        var behaviorSection = (BehaviorsSection)serviceModelSectionGroup.Sections["behaviors"];
    
        bindingSection.NetTcpBinding.Bindings.Clear();
        clientsection.Endpoints.Clear();
        var filterTable = new FilterTableEntryCollection() { Name = "RoutingTable" };
        routingSection.Filters.Clear();
        routingSection.FilterTables.Clear();
        routingSection.BackupLists.Clear();
    
        var nettcpBinding = new NetTcpBindingElement()
        {
            Name = "myTcpBinding",
            TransferMode = TransferMode.Buffered,
            MaxBufferSize = 2147483647,
            MaxReceivedMessageSize = 2147483647,        
            SendTimeout = new TimeSpan(0, 10, 0),
            ReceiveTimeout = new TimeSpan(0, 10, 0),
    
        };
    
        nettcpBinding.Security.Mode = SecurityMode.None;
        bindingSection.NetTcpBinding.Bindings.Add(nettcpBinding);
    
    
        foreach (var endpointGroup in groupedEndpoitns)
        {
            var backupListItem = new BackupEndpointCollection();
            backupListItem.Name = endpointGroup.ServiceName + "Backup";
    
            var filter = new FilterElement();
            filter.Name = endpointGroup.ServiceName + "Filter";
            filter.FilterType = FilterType.Custom;
            filter.CustomType = "MyServiceContractMessageFilterType,asemblyName";
            filter.FilterData = endpointGroup.EndPoint.FirstOrDefault().ClientTypeName;
            routingSection.Filters.Add(filter);
    
            int endpointCount = 0;
            List<ChannelEndpointElement> channelEndpoints = new List<ChannelEndpointElement>();
            foreach (var endpoint in endpointGroup.EndPoint)
            {
                endpointCount++;
                var channelEndpoint = new ChannelEndpointElement();
                channelEndpoint.Address = new Uri(endpoint.Url);
                channelEndpoint.Binding = "netTcpBinding";
                channelEndpoint.BindingConfiguration = "myTcpBinding";
                channelEndpoint.Contract = "*";
                channelEndpoint.Name = $"{endpoint.Name}EndPoint{endpointCount}";
                clientsection.Endpoints.Add(channelEndpoint);
                channelEndpoints.Add(channelEndpoint);
    
            }
    
            var firstChannelEndpoint = channelEndpoints.FirstOrDefault(); /// this endpoint will be selected as main endpoint
            var filterTableItem = new FilterTableEntryElement();
            filterTableItem.FilterName = filter.Name;
            filterTableItem.EndpointName = firstChannelEndpoint.Name;
            filterTableItem.BackupList = backupListItem.Name;
            filterTable.Add(filterTableItem);    
            
            foreach (var backupEndpoints in channelEndpoints)
            {
                backupListItem.Add(new BackupEndpointElement() { EndpointName = backupEndpoints.Name });
                routingSection.BackupLists.Add(backupListItem);
            }
        }
    
        routingSection.FilterTables.Add(filterTable);    
        behaviorSection.ServiceBehaviors.Clear();
        var behavior = new ServiceBehaviorElement();
        behavior.Add(new RoutingExtensionElement() { FilterTableName = filterTable.Name });
        behaviorSection.ServiceBehaviors.Add(behavior);
        config.Save(ConfigurationSaveMode.Modified, false);
        ConfigurationManager.RefreshSection("system.serviceModel/routing");
        ConfigurationManager.RefreshSection("system.serviceModel/client");        
    ConfigurationManager.RefreshSection("system.serviceModel/behaviors");
    }
