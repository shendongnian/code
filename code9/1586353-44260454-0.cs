    CustomFilePropertiesPart customPropsPart = doc.CustomFilePropertiesPart;
    DocumentFormat.OpenXml.CustomProperties.Properties props = customPropsPart.Properties;
    
    foreach (DocumentFormat.OpenXml.CustomProperties.CustomDocumentProperty prop in props)
    {
      //do what you want to do... in my case I have only one Text property...
      String propName = prop.Name;
      String value = prop.VTLPWSTR.InnerText;
    }
