    public Array AddEmail()
    {
        string[] dRemail = { "", "", "" };
        if (File.Exists(@"\\fs01\Applications\EMS-Manager\DREmailAddresses.xml"))
        {
            XmlReader emailDocument = new XmlTextReader(@"\\fs01\Applications\EMS-Manager\DREmailAddresses.xml");
            while (emailDocument.Read())
            {
                var type = emailDocument.NodeType;
                switch (type)
                {
                    case XmlNodeType.Element:
                        if (emailDocument.Name == "DRCreatedAddEmail")
                        {
                            dRemail[0] = emailDocument.ReadInnerXml();
                        }
                        else if (emailDocument.Name == "DRActionNeededAddEmail")
                        {
                            dRemail[1] = emailDocument.ReadInnerXml();
                        }
                        else if (emailDocument.Name == "DRPendingAddEmail")
                        {
                            dRemail[2] = emailDocument.ReadInnerXml();
                        }
                        else
                        {
                            MessageBox.Show("Unknown node type " + emailDocument.Name);
                        }
                        break;
                }
            }
        }
        else
        {
             MessageBox.Show(@"The file: 'DREmailAddresses.xml' was not found at: \\fs01\Applications\EMS-Manager");
        }
        return dRemail;
    }
