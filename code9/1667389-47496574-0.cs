    XmlNodeList list = doc.SelectNodes("//*[starts-with(name(), 'longname')]");
    for (int i = 0; i < list.Count; i++)
    {
        Console.WriteLine(list[i].Name); // longname_it, longname_es, ...
        /*
        Do your stuff here...
        */
    }
