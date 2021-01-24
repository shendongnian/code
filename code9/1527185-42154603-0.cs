        XDocument xml = XDocument.Load("D:\\test.xml");
        foreach (var node in xml.DescendantNodes())
        {
                if (node is XText)
                {
                    MessageBox.Show(((XText)node).Value);
                    //some code...
                }
        }
