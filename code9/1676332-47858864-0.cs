    namespace testReadXmlGame
    {
        public static class XmlFileRead
        {
            #region public methods
    
            public static List<List<string>> XmlDataToList(string pathToXmlFile, bool addToFile, List<List<string>> imageData)
            {
                XmlReader xmlReader = XmlReader.Create(pathToXmlFile);
                while (xmlReader.Read())
                {
                    List<string> tempData = new List<string>(); // create a temp list to add data from each node
    
                    while (xmlReader.MoveToNextAttribute())
                    {
                        tempData.Add(xmlReader.Value);
                        addToFile = true;
                    }
    
                    if (addToFile)
                    {
                        imageData.Add(tempData);
                        addToFile = false;
                    }
                }
               
                return imageData;
            }
            #endregion
        }
    }
