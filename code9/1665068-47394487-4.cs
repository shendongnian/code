    foreach (XElement xElem in xDoc.Element("Attachments").Descendants())
    {
          if(!string.IsNullOrWhiteSpace(xElem?.Value))
          {
               byte[] attachement = Convert.FromBase64String(xElem.Value);
               // rest of a code
          }
    } 
