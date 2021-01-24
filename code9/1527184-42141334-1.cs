    XDocument xml = XDocument.Load("D:\\test.xml");
    foreach (var node in xml.DescendantNodes().OfType<XText>())
    {
        var value = node.Value.Trim();
        if (!string.IsNullOrEmpty(value))
        {
            MessageBox.Show(value);
            //some code...
        }
    }
