     public static void CreateResourceFile()
                {
                    string resourceFileName = "externeresource";
        
                        System.Xml.XmlDocument xmldoc = new XmlDocument();
                        XmlTextReader reader = new XmlTextReader("/runtimeWPForm.xml");
                        reader.WhitespaceHandling = WhitespaceHandling.None;
                        xmldoc.Load(reader);
       
                        ResourceWriter resourceWriter = new ResourceWriter(resourceFileName);
    /*Add XmlDocument must be Serializable to store it in     
                        resourceWriter.AddResource("xamlgrid", xmldoc.ToString());   
    the Resource, so i stored a String here. (not testet)*/
                        resourceWriter.Close();
        
                        MessageBox.Show("File " + resourceFileName + " created");
                        reader.Close();
        
                }
