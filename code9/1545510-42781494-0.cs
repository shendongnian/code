     if (yourCondition)
     {
         XmlAttributes myRequestClassPropertyAttributes = new XmlAttributes();
         myRequestClassPropertyAttributes.XmlIgnore = true;
         XmlAttributeOverrides myRequestClassAttributes = new XmlAttributeOverrides();
         myRequestClassAttributes.Add(typeof(MyRequestClass), "MOBNO", myRequestClassPropertyAttributes);
         XmlSerializer xsSubmit = new XmlSerializer(typeof(MyRequestClass), myRequestClassAttributes);
         using (StringWriter sww = new StringWriter())
         {
              using (XmlWriter writer = XmlWriter.Create(sww))
              {
                   //  sww.WriteLine(@"<?xml version=""1.0"" encoding=""UTF-8""?>");
                   xsSubmit.Serialize(writer, env);
                   output = sww.ToString();
              }
          }
    }
