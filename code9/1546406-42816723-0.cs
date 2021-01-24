    var app = new Microsoft.Office.Interop.Word.Application();
    
    var doc = app.Documents.Open(FileName: @"C:\Users\rschrieken\Downloads\character-safe.docx", Encoding: MsoEncoding.msoEncodingUSASCII);
   
    // forget Interop, hello XML
    var cd = XDocument.Parse(doc.WordOpenXML);
    
    var w = (XNamespace)"http://schemas.openxmlformats.org/wordprocessingml/2006/main";
    
    var sb = new StringBuilder();
    
    foreach (var para in cd.Descendants(w + "p"))
    {
        foreach (var node in para.Descendants())
        {
            if (node.Name.LocalName == "t")
            {
                Console.Write(node.Value);
                sb.Append(node.Value);
            }
            if (node.Name.LocalName == "sym")
            {
                var sym = node.Attribute(w + "char").Value;
                // this will convert the hex value
                var val = Convert.ToInt32(sym, 16);
                // depending on your requirements, you might have to re-map this
                // but I simply assume here that hex value is an valid Unicode char 
                Console.Write((char)val);
                sb.Append((char) val);
            }
        }
        Console.WriteLine();
        sb.AppendLine();
    }
    // sb.ToString() gives you the text from the document
