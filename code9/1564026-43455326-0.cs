    switch (reader.NodeType) {
          case XmlNodeType.Element:
              sw.Write(string.Format("<{0}>", reader.Name));
              break;
          case XmlNodeType.Text:
              sw.Write(reader.Value);
              break;
           case XmlNodeType.CDATA:
               sw.Write(string.Format("<![CDATA[{0}]]>", reader.Value));
               break;
           case XmlNodeType.ProcessingInstruction:
               sw.Write(string.Format("<?{0} {1}?>", reader.Name, reader.Value));
               break;
           case XmlNodeType.Comment:
               sw.Write(string.Format("<!--{0}-->", reader.Value));
               break;
           case XmlNodeType.XmlDeclaration:
               sw.Write("<?xml version='1.0'?>");
               break;
           case XmlNodeType.Document:
               break;
           case XmlNodeType.DocumentType:
               sw.Write(string.Format("<!DOCTYPE {0} [{1}]", reader.Name, reader.Value));
               break;
           case XmlNodeType.EntityReference:
               sw.Write(reader.Name);
               break;
           case XmlNodeType.EndElement:
               sw.Write(string.Format("</{0}>", reader.Name));
               break;
       } 
