      var output = new StringBuilder();
      foreach (XmlNode customer in workUnit)
      {
           // fresh instance of the class that holds all columns (so all properties are cleared)
           var unit = new WorkUnit();
           var childNodes = customer.SelectNodes("./*");
           if (childNodes != null)
           {
                foreach (XmlNode childNode in childNodes)
                {
                    if(childNode.Name== "tlp:EmployeeID")
                    {
                         // employeeID node found, now write to the corresponding property:
                         unit.EmployeeId = childNode.InnerText;
                    }
                    // etc for the other XML nodes you are interested in
                }
                // all nodes have been processed for this one WorkUnit node
                // so write a line to the CSV
                output.AppendLine($"{unit.EmployeeId},{unit.AllocationId}, etc");
           }
