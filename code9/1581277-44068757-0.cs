    using (var inFile = new FileStream(path, FileMode.Open))
        {
            using (var reader = new XmlTextReader(inFile))
            {
                while (reader.Read())
                {
                     
                            if ( reader.NodeType == XmlNodeType.Element && reader.Name == "book" && reader.GetAttribute(0) == "bk103")
                            {
        
                              
                            }
                           
                    }
                }
            }
        }
