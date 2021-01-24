            DuplexChannelFactory<IService> cf = new DuplexChannelFactory<IService>(typeof(ServiceCallback), Server.ServerBinding(), ep);
            foreach (OperationDescription operation in cf.Endpoint.Contract.Operations)
            {
                var dc = operation.Behaviors.Find<DataContractSerializerOperationBehavior>();
                if (dc != null)
                {
                    dc.MaxItemsInObjectGraph = int.MaxValue;
                }
            }
