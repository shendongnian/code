    private bool myFunction(List<XElement> jobList)
    {
        List<XElement> tempJobList = new List<XElement>();
        foreach (var element in jobList)
        {
            // Take a copy
            var tempElement = new XElement(element);
            tempJobList.Add(tempElement);
        }
        foreach (XElement elements in tempJobList)
        {
            elements.Attribute("someattribute").Remove();
        }
    }
