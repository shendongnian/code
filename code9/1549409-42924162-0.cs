     ServiceEndpoint se = new ServiceEndpoint(new ContractDescription("IService1"), new BasicHttpBinding(), new EndpointAddress("basic"));  
                se.Behaviors.Add(new MyEndpointBehavior());  
                config.AddServiceEndpoint(se);  
      
                config.Description.Behaviors.Add(new ServiceMetadataBehavior { HttpGetEnabled = true });  
                config.Description.Behaviors.Add(new ServiceDebugBehavior { IncludeExceptionDetailInFaults = true });  
