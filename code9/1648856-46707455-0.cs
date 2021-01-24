    if (((XElement)xN).Value == value)
    {
        XNamespace myNs = ((XElement)xN).Name.Namespace;
        myResultSet[0].Add(new ResultSet(file, myX.Root.Descendants(myNs + "MessageVersion").First().Value));
    }
