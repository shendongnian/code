    class Group
    {
        public string Id { get; set; }
        //You can add other group content
    }  
    XElement xmlFileContent = XElement.Load("filePath");
    var groupXmlFormat = xmlFileContent.Descendants("group")
                                                    .Select(group =>
                                                    {
                                                        return new Group
                                                        {
                                                            Id=group.Attribute("id").Value,
                                                        };
                                                    }).ToList();
