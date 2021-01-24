    var WS_LookupFields = "attr2,attr3".Split(',').ToList();
    var output = XDocument.Parse(WS_Output_Raw);
    foreach (var loElement in output.Descendants("element"))
    {
        //loElement.Attributes()
        //    .Where(item => !WS_LookupFields.Any(name => item.Name == name))
        //    .ToList()
        //    .ForEach(item => item.Remove());
        //UPDATE: Charles Mager
        loElement.Attributes()
            .Where(item => !WS_LookupFields.Any(name => item.Name == name))
            .Remove();
    }
