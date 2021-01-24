     static void PrintEndpoints(ServiceDescription desc)
            {
                Console.WriteLine(desc.Name);
                foreach (ServiceEndpoint nextEndpoint in desc.Endpoints)
                {
                    Console.WriteLine();
                    Console.WriteLine(nextEndpoint.Address);
                }
            }
