         using(System.ServiceModel.ServiceHost host = 
    new  System.ServiceModel.ServiceHost(typeof(ReceivingMethodsnamespace.ReceivingMethods )))
               {
                  host.Open();
                  Console.WriteLine("Host started @ " + DateTime.Now.ToString());
                  Console.ReadLine();
               }
