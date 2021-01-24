            System.Xml.XmlDocument myDoc = new System.Xml.XmlDocument();
            try
            {
                myDoc.Load(XMLFullFileName);
            }
            catch (Exception e)
            {
                throw new Exception("Loading failed!", e);
            }
