    IDataObject dataObject = Clipboard.GetDataObject();
    System.IO.MemoryStream stream = dataObject.GetData("XML Spreadsheet") as System.IO.MemoryStream;
    if(stream != null)
    {
        stream.SetLength(stream.Length - 1);
        XElement xml = XElement.Load(stream);
        XNamespace ns = "urn:schemas-microsoft-com:office:spreadsheet";
        double actualValue;
        var data = xml.Descendants(ns + "Data").Where(x => (string)x.Attribute(ns + "Type") == "Number");
        if(data != null && data.Any())
        {
            actualValue = (double)data.First();
            MessageBox.Show(actualValue.ToString());
        }
        stream.Dispose();
    }
