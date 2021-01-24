     public static void XMLToDataTable()
        {
            XDocument doc = XDocument.Load(@"D:\\Sample.xml");
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("unicode");
            dt.Columns.Add("glyph_name");
            dt.Columns.Add("d");
            string[] arr = new string[3];
            var dr = from n in doc.Descendants("glyph")
                     select new string[]{ 
                         arr[0] = n.Attribute("unicode").Value,
                         arr[1] = n.Attribute("glyph-name").Value,
                         arr[2] = n.Attribute("d").Value
                     };
            foreach (var item in dr)
            {
                dt.Rows.Add(item[0],item[1],item[2]);
            }
        }
