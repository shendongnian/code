    public class Stuff
    {
        private List<string> Items;
        private static string Connection()
        {
            return ConfigurationManager.ConnectionStrings["deliverycon"].ToString();
        }
        public bool DoStuff()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Connection()))
                {
                    using (SqlCommand cmd = new SqlCommand("AddNewBestellung", con))
                    {
                        cmd.Parameters.AddWithValue("@Items", ConstructXmlFromList(Items));
                        //other saved parameters...
                        con.Open();
                        int i = cmd.ExecuteNonQuery();
                        con.Close();
                        if (i >= 1)
                            return true;
                        else
                            return false;
                    }
                }
            }
            catch (Exception ex)
            {
                string e = ex.Message;
                return false;
            }
        }
        public static T FromXML<T>(string xml)
        {
            using (var stringReader = new StringReader(xml))
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(stringReader);
            }
        }
        public string ToXML<T>(T obj)
        {
            using (var stringWriter = new StringWriter(new StringBuilder()))
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(stringWriter, obj);
                return stringWriter.ToString();
            }
        }
        private string ConstructXmlFromList(List<string> list)
        {
            return ToXML(list);
        }
    }
