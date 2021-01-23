    private static void Main(string[] args)
    {
        using (var conn = new SqlConnection(
                    "Server=************.database.windows.net,"+
                    "0000;Database=testdb;User ID=testuser;"+"
                    Password= testpassword;Trusted_Connection=False;"+
                    "Encrypt=True;Connection Timeout=30;"))
        {
            conn.Open();
            using (var cmd = new SqlCommand(
                   "SELECT * FROM District WHERE leaID <= 4 FOR XML PATH('districtEntry'), ROOT('districts')", conn))
            {
                using (var reader = cmd.ExecuteXmlReader())
                {
                    if (reader == null) return;
                    StringBuilder sb = new StringBuilder();
                    While(reader.Read())
                    {
                        sb.AppendLine(reader.ReadOuterXml());
                        string xmlVal = sb.ToString(); // You can get the xml as string here.
                    }  
                }
            }
        }
    }
