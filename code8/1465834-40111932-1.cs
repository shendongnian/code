    if (item != null && item.HasLineInfo())
    {
        string id = (((XObject)item).Parent.Element("id")).Value;
        Message = dict[id] + ";" +
            item.LineNumber + ";" +
            id + ";" +
            ((XElement)item).Name.LocalName + ";" +
            args.Message + Environment.NewLine;
        lstErrors.Add(Message);
    }
