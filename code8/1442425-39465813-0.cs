    class GetData
    {
        public async Task<object> obj_get_data(string xml_file)
        {
            XDocument xdoc = await XDocument.Load(xml_file);
            var list_emp = from query in xdoc.Descendants("emp")
                            select new du_lieu.thong_tin
                            {
                                Name = (string)query.Element("age"),
                                Age = (string)query.Element("age"),
                            };
            return list_emp;
        }
    }
