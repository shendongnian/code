    if (item != null && item.HasLineInfo())
    {
        Message = dict[((XObject)item).Parent] + ";" +
            item.LineNumber + ";" +
            (((XObject)item).Parent.Element("id")).Value + ";" +
            ((XElement)item).Name.LocalName + ";" +
            args.Message + Environment.NewLine;
        lstErrors.Add(Message);
    }
