                var url = ConfigurationManager.AppSettings["serviceLink"];
                var serviceClientClassName = ConfigurationManager.AppSettings["serviceClientClassName"];
                var serviceMethod = ConfigurationManager.AppSettings["serviceMethod"];
                var endpoint = new EndpointAddress(new Uri(url));
                //Specify the assembly of services library. I am assuming that the services are stored in the Executing Assembly
                var serviceClient = Assembly.GetExecutingAssembly().GetTypes()
                    .FirstOrDefault(x => x.Name == serviceClientClassName);//Find the service client type
                var instance = Activator.CreateInstance(serviceClient); //Create a new instance of type
                var methodInfo = serviceClient.GetMethod(serviceMethod); //Get method info
                var result = methodInfo.Invoke(instance, new object[] {});  // Invoke it
