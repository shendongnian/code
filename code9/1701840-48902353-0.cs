    var body = new XElement("body");
    using (SqlConnection conn = new SqlConnection(conString))
    {
        string query = string.Format("{0}{1}'", "SELECT [VALUE1],[VALUE2] FROM ...");
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
            {
                while (reader.Read())
                {
                    body.Add(new XElement("tr",
                        new XElement("td", reader["VALUE1"]),
                        new XElement("td", reader["VALUE2"])));
                }
            }
        }
    }
    var document = new XDocument(
        new XDocumentType("html", null, null, null),
        new XElement("html", new XElement("head"), body));
