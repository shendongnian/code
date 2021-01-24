            StringBuilder csvContent = new StringBuilder();
            // add the header line
            csvContent.AppendLine("AllocationID,ApprovedStatus,CustomerId,CustomerName,EmployeeID");
            foreach (var unit in workUnits.WorkUnit)
            {
                csvContent.AppendFormat(
                    "{0}, {1}, {2}, {3}, {4}",
                    new object[] 
                    {
                        unit.AllocationID,
                        unit.ApprovedStatus,
                        unit.CustomerId,
                        unit.CustomerName,
                        unit.EmployeeID
                        // you get the idea
                    });
                csvContent.AppendLine();
            }
            File.WriteAllText(@"G:\Projects\StackOverFlow\WpfApp1\WorkUnits.csv", csvContent.ToString());
