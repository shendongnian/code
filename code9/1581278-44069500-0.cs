            bool isFoundId = false;
            string title = string.Empty;
            string author = string.Empty;
            using (var str = File.OpenRead("data.xml"))
            {
                using (XmlReader reader = new XmlTextReader(str))
                {
                    while (reader.Read())
                    {
                        if (reader.Name == "book")
                        {
                            var v = reader.GetAttribute("id");
                            if (v == "bk101")
                            {
                                isFoundId = true;
                            }
                            else if (isFoundId)
                            {
                                break;
                            }
                        }
                        if (isFoundId && reader.Name == "title")
                        {
                            title = reader.ReadElementContentAsString();
                        }
                        if (isFoundId && reader.Name == "author")
                        {
                            author = reader.ReadElementContentAsString();
                        }
                    }
                }
            }
