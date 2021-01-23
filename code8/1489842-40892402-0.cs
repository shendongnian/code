    List<StringBuilder> splitByProtocol = new List<StringBuilder>();
    foreach (string s in lineSplit)
    {
        string protocol = getProtocol();
        index = protocolTypes.IndexOf(protocol);
        splitByProtocol[index].AppendLine(s);
    }
