            ServiceHost host = new ServiceHost(proxy);
            host.Open();
            Console.WriteLine("Running...");
            Console.ReadLine();
            try
            {
                host.Close();
            }
            catch
            {
                host.Abort();
            }
