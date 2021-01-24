        public static DummyBook XML(string XMLPath)
        {
            DummyBook dummyBook = new DummyBook();
            XmlTextReader reader = new XmlTextReader(XMLPath);
            while (reader.Read())
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name == "Title")
                        dummyBook.Name = reader.ReadString();
                    else if (reader.Name == "Author")
                        dummyBook.Author += reader.ReadString() + ", ";
                    else if (reader.Name == "PublicationDate")
                        dummyBook.PublishedDate = reader.ReadString();
                    else if (reader.Name == "Publisher")
                        dummyBook.Publisher = reader.ReadString();
                    else if (reader.Name == "NumberOfPages")
                        dummyBook.PageCount = reader.ReadString();
                    else if (reader.Name == "Language")
                    {
                        if (reader.ReadToDescendant("Name"))
                            dummyBook.Language = reader.ReadString();
                    }
                    else if (reader.Name == "Content")
                        dummyBook.AdditionalInfo = reader.ReadString();
                    else if (reader.Name == "ImageSet")
                    {
                        if (reader.GetAttribute("Category").ToString() == "primary")
                        {
                            if (reader.ReadToDescendant("LargeImage"))
                                if (reader.ReadToDescendant("URL"))
                                    dummyBook.CoverFrontURL = reader.ReadString();
                        }
                        else if (reader.GetAttribute("Category").ToString() == "variant")
                        {
                            if (reader.ReadToDescendant("LargeImage"))
                                if (reader.ReadToDescendant("URL"))
                                    dummyBook.CoverBackURL = reader.ReadString();
                        }
                    }
                }
            reader.Close();
            return dummyBook;
        }
