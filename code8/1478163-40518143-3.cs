    var xml = XDocument.Load("data.xml");
    var sb = new StringBuilder();
    foreach (var node in xml.Descendants("SPSecurableObject"))
    {
        var objectName = node.Element("ObjectName").Value;
        if (node.Element("RoleAssignments") == null)
        {
            sb.Append(objectName).AppendLine(",,,");
            continue;
        }
        var lines = node.Descendants("SPRoleAssignment")
            .Select(elem => string.Join(",", elem.DescendantNodes().OfType<XText>()));
        if (lines.Any())
        {
            foreach (var line in lines)
                sb.Append(objectName).Append(',').AppendLine(line);
        }
        else
        {
            sb.Append(objectName).AppendLine(",,,");
        }
    }
    Console.WriteLine(sb);
