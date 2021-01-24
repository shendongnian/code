    public static void Main()  
            {  
                Uri baseAddress = new Uri("http://localhost/MyServer/MyService");  
    
                try  
                {  
                    ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService));  
    
                    WSHttpBinding binding = new WSHttpBinding();  
                    binding.OpenTimeout = new TimeSpan(0, 10, 0);  
                    binding.CloseTimeout = new TimeSpan(0, 10, 0);  
                    binding.SendTimeout = new TimeSpan(0, 10, 0);  
                    binding.ReceiveTimeout = new TimeSpan(0, 10, 0);  
    
                    serviceHost.AddServiceEndpoint("ICalculator", binding, baseAddress);  
                    serviceHost.Open();  
    
                    // The service can now be accessed.  
                    Console.WriteLine("The service is ready.");  
                    Console.WriteLine("Press <ENTER> to terminate service.");  
                    Console.WriteLine();  
                    Console.ReadLine();  
    
                }  
                catch (CommunicationException ex)  
                {  
                    // Handle exception ...  
                }  
            }
