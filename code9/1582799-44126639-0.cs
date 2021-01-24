     string hostName = Environment.MachineName;
            string[] buildingCode = { "B1", "B2", "B3", "B4" };
            string[] buildingName = { "Building 1", "Building 2", "Building 3", "Building 4" };
            if (buildingCode.Where(t => t.Contains(hostname)).Any())
            {
                Console.Write(buildingCode
                .Where(t => t.Contains(hostname))
                 .FirstOrDefault());
            }
