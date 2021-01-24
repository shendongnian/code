    var output = new StringBuilder();
    output.AppendLine("AllocationID,ApprovedStatus,CustomerId,CustomerName,EmployeeID");
    if (workUnit != null)
    {
        foreach (XmlNode customer in workUnit)
        {
            var unit = new WorkUnit();
            var childNodes = customer.SelectNodes("./*");
            if (childNodes != null)
            {
                for (int i = 0; i<childNodes.Count; ++i)
                {
                    XmlNode childNode = childNodes[i];
                    if (childNode.Name == "tlp:EmployeeID")
                    {
                        unit.EmployeeID = Int32.Parse(childNode.InnerText);
                    }
                    if (childNode.Name == "tlp:EmployeeFirstName")
                    {
                        unit.EmployeeFirstName = childNode.InnerText;
                    }
                    if (childNode.Name == "tlp:EmployeeLastName")
                    {
                        unit.EmployeeLastName = childNode.InnerText;
                    }
                    if (childNode.Name == "tlp:AllocationID")
                    {
                        unit.AllocationID = Int32.Parse(childNode.InnerText);
                    }
                    if (childNode.Name == "tlp:TaskName")
                    {
                        unit.TaskName = childNode.InnerText;
                    }
                    output.Append(childNode.InnerText);
                    if (i<childNodes.Count - 1)
                        output.Append(",");
                }
                output.Append(Environment.NewLine);
            }
        }
        Console.WriteLine(output.ToString());
        File.WriteAllText("c:\\Users\\mnowshin\\projects\\WorkUnits.csv", output.ToString());
    }
