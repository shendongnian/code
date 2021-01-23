        Host = new ServiceHost(typeof(MyService));
        ContractDescription cd = Host.Description.Endpoints[0].Contract;
        foreach (var operation in cd.Operations)
        {
            operation.Behaviors.Find<DataContractSerializerOperationBehavior>()
                    .DataContractResolver = new SharedTypeResolver();
        }
