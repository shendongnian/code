    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(Order));
            var subReq = new Order { Cargo  = new List<Cargo>{new Cargo { Name = "test" }, new Cargo { Name = "foo" }}, AddedService = new List<AddedService>{new AddedService{Name="addedService"}}, Custid = "custId", Pay_method = "bla"};
            var xml = "";
            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, subReq);
                    xml = sww.ToString(); // Your XML
                }
            }
        }
    }
