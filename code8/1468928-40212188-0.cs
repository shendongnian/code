     string strFilename = "/Message.xml";
                strFilename = Server.MapPath(strFilename);
                XmlDocument xmlDoc = new XmlDocument();
    
                if (File.Exists(strFilename))
                {
                    XmlTextReader rdrXml = new XmlTextReader(strFilename);
    
                    do
                    {
                        switch (rdrXml.NodeType)
                        {
                            case XmlNodeType.Text:
    
                                //Console.WriteLine("{0}", rdrXml.Value);
                                Response.Write(rdrXml.Value + "<br/>");
                                break;
                        }
                    } while (rdrXml.Read());
                }
