    var results = true;
    var msg = new List<string>(0);
    XDocument aDocument = null;
    try
    {
        aDocument = XDocument.Load(%xmlFileName%);
    }
    catch (Exception e)
    {
        results = false;
        msg.Add(string.Format("Unable to open file:{0}", model.FileName));
        msg.Add(e.Message);
    }
    
    if (aDocument != null)
    {
        var thePeople = aDocument.Descendants("Person").ToArray();
    
        if (thePeople.Any())
        {
          // there were people in the file. People is an array of XML Nodes containing your person.
         }
        else
        {
            results = false;
            msg.Add("No people found.");
        }
    }
