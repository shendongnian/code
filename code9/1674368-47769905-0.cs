      var output = new StringBuilder();
      foreach (XmlNode customer in workUnit)
      {
           var unit = new WorkUnit();
           var childNodes = customer.SelectNodes("./*");
           if (childNodes != null)
           {
                foreach (XmlNode childNode in childNodes)
                {
                    if(childNode.Name== "tlp:EmployeeID")
                    {
                         unit.EmployeeId = childNode.InnerText;
                    }
                    // etc
                }
                output.AppendLine($"{unit.EmployeeId},{unit.AllocationId}, etc");
           }
