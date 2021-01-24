        static void Main(string[] args)
        {
            string str = @"<Accounts><Number credit=""1000"">100987654321</Number><Number credit=""0"">100987654322</Number></Accounts>";
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(str)))
            {
                XmlSerializer ser = new XmlSerializer(typeof(Accounts));
                var cust = (Accounts)ser.Deserialize(stream);
            }
        }
