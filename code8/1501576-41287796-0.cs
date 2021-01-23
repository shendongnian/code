    // Return an XmlSerializer used for overriding.
       public XmlSerializer CreateOverrider()
       {
          // Create the XmlAttributeOverrides and XmlAttributes objects.
          XmlAttributeOverrides xOver = new XmlAttributeOverrides();
          XmlAttributes attrs = new XmlAttributes();
    
          /* Setting XmlIgnore to false overrides the XmlIgnoreAttribute
             applied to the Comment field. Thus it will be serialized.*/
          attrs.XmlIgnore = false;
          xOver.Add(typeof(Group), "Comment", attrs);
    
          /* Use the XmlIgnore to instruct the XmlSerializer to ignore
             the GroupName instead. */
          attrs = new XmlAttributes();
          attrs.XmlIgnore = true;
          xOver.Add(typeof(Group), "GroupName", attrs);
    
          XmlSerializer xSer = new XmlSerializer(typeof(Group), xOver);
          return xSer;
       }
    
       public void SerializeObject(string filename)
       {
          // Create an XmlSerializer instance.
          XmlSerializer xSer = CreateOverrider();
    
          // Create the object to serialize and set its properties.
          Group myGroup = new Group();
          myGroup.GroupName = ".NET";
          myGroup.Comment = "My Comment...";
    
          // Writing the file requires a TextWriter.
          TextWriter writer = new StreamWriter(filename);
    
          // Serialize the object and close the TextWriter.
          xSer.Serialize(writer, myGroup);
          writer.Close();
       }
