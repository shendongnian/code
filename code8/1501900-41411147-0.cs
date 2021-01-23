    var pictures = _pictureService.GetPicturesByProductId(items.id) 
    
    foreach(item in pictures)
    {
        writer.WriteStartElement("IMAGE");
        writer.WriteString(item.SeoFilename);
        writer.WriteEndElement();
    }
  
