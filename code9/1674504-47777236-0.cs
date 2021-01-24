    var workUnit = customersRaw.SelectNodes("tlp:WorkUnit", namespaceManager);
    if (workUnit != null)
    {
        var output = new StringBuilder();
        foreach (XmlNode customer in workUnit)
        {
            //var unit = new WorkUnit();
            var childNodes = customer.SelectNodes("./*");
            if (childNodes != null)
            {
                for (int i = 0; i<childNodes.Count; ++i)
                {
                    XmlNode childNode = childNodes[i];
                    /*if (childNode.Name == "tlp:EmployeeID")
                    {
                        unit.EmployeeID = Int32.Parse(childNode.InnerText);
                    }
                    if (childNode.Name == "tlp:EmployeeFirstName")
                    {
                        unit.ProjectName = childNode.InnerText;
                    }
                    if (childNode.Name == "tlp:EmployeeLastName")
                    {
                        unit.ProjectName = childNode.InnerText;
                    }
                    if (childNode.Name == "tlp:AllocationID")
                    {
                        unit.ProjectName = childNode.InnerText;
                    }
                    if (childNode.Name == "tlp:TaskName")
                    {
                        unit.ProjectName = childNode.InnerText;
                    }*/
                    output.Append(childNode.InnerText);
                    if(i<childNodes.Count - 1)
                        output.Append(",");
                }
                output.Append(Environment.NewLine);
            }
        }
    }
