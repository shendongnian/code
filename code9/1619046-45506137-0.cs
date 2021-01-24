    XmlTextReader myReader = new XmlTextReader("./Redirect.xml");   
    while (myReader.Read())
    {
        if (myReader.NodeType==XmlNodeType.Element&&myReader.Name=="FL")                
        {
            if (myReader.GetAttribute("val") == "POTENTIALID")
            {
                Console.WriteLine(myReader.ReadString());
            }                    
        }
     }
