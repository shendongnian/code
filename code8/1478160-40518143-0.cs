    var xml = XDocument.Load("data.xml");
    var something = string.Join(Environment.NewLine,
        xml.Descendants("ObjectName").Select(elem => elem.Value));
    var lines = xml.Descendants("SPRoleAssignment")
        .Select(elem => string.Join(",", elem.DescendantNodes().OfType<XText>()));
    var sb = new StringBuilder();
    sb.AppendLine(something);
    foreach (var line in lines)
        sb.AppendLine(line);
    Console.WriteLine(sb);
